using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using Nameless.Libraries.Rukia.ProjectEuler.Utility.Threading;
using Nameless.Libraries.Yggdrasil.Frau.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// Each character on a computer is assigned a unique code and the preferred standard is ASCII (American Standard Code for Information Interchange). 
    /// For example, uppercase A = 65, asterisk (*) = 42, and lowercase k = 107.
    /// A modern encryption method is to take a text file, convert the bytes to ASCII, then XOR each byte with a given value, taken from a secret key. 
    /// The advantage with the XOR function is that using the same encryption key on the cipher text, restores the plain text; for example, 65 XOR 42 = 107, then 107 XOR 42 = 65.
    /// For unbreakable encryption, the key is the same length as the plain text message, and the key is made up of random bytes. 
    /// The user would keep the encrypted message and the encryption key in different locations, and without both "halves", it is impossible to decrypt the message.
    /// Unfortunately, this method is impractical for most users, so the modified method is to use a password as a key. 
    /// If the password is shorter than the message, which is likely, the key is repeated cyclically throughout the message. 
    /// The balance for this method is using a sufficiently long password key for security, but short enough to be memorable.
    /// Your task has been made easy, as the encryption key consists of three lower case characters. 
    /// Using p059_cipher.txt resources, a file containing the encrypted ASCII codes, and the knowledge that the plain text must contain common English words, decrypt the message and find the sum of the ASCII values in the original text.
    /// </summary>
    public class XORDecryption : ISolution<long>
    {
        PoolThread Pool;
        /// <summary>
        /// The list of asscii small caps letters
        /// </summary>
        Char[] ASCII_LETTERS = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        String[] encryptedMsg;
        public long Result
        {
            get { return this.Solve(); }
        }

        public long Solve()
        {
            var result = Pool.Run();
            Console.WriteLine((result as Object[])[2]);
            return ChipherThread.Decrypt(ChipherThread.EncryptedMessage, (result as Object[])[1] as char[]).Sum();
        }

        public XORDecryption()
        {
            Pool = new PoolThread();
            InitThreads();
            Pool.TaskIsFinished = TaskIsFinished;
            Pool.ReportingTaskProgress = ReportTask;
        }

        public void InitThreads()
        {
            const int MAX_THREADS = 100 ;
            encryptedMsg = Resources.Resources.p059_cipher.Split(',');
            int blockSize = (int)((double)encryptedMsg.Length / (double)MAX_THREADS);
            List<String> cKeys = GetKeyCombinations();
            List<String[]> blockKeys = GetBlocks(cKeys, cKeys.Count / MAX_THREADS, MAX_THREADS);
            for (int i = 0; i < MAX_THREADS; i++)
                Pool.Add(new ChipherThread(encryptedMsg, blockKeys[i]));
        }

        private List<string[]> GetBlocks(List<string> cKeys, int blockSize, int size)
        {
            List<string[]> blocks = new List<string[]>();
            string[] blockKey = new String[blockSize];
            Boolean lastBlock = false;
            for (int i = 0, j = 0; i < cKeys.Count; i++, j++)
            {
                if (blocks.Count == size - 1 && !lastBlock)
                {
                    int diff = cKeys.Count - blockSize * size;
                    j = 0;
                    String[] current = blockKey;
                    blockKey = new String[blockSize + diff];
                    while (current[j] != null)
                    {
                        blockKey[j] = current[j];
                        j++;
                    }
                    lastBlock = true;
                }
                else if (j == blockSize && !lastBlock)
                {
                    j = 0;
                    blocks.Add(blockKey);
                    blockKey = new String[blockSize];
                }
                blockKey[j] = cKeys[i];
            }
            blocks.Add(blockKey);
            return blocks;
        }

        private List<String> GetKeyCombinations()
        {
            List<String> keys = new List<String>();
            for (int i = 0; i < ASCII_LETTERS.Length; i++)
                for (int j = 0; j < ASCII_LETTERS.Length; j++)
                    for (int k = 0; k < ASCII_LETTERS.Length; k++)
                        keys.Add(new String(new Char[] { ASCII_LETTERS[i], ASCII_LETTERS[j], ASCII_LETTERS[k] }));
            return keys;
        }

        public void ReportTask(IEnumerable<FrauThread> threads)
        {
            Console.Clear();
            Console.WriteLine(Pool.Percent);
        }

        public static object TaskIsFinished(object[] input)
        {
            input = input.OrderBy(x => (double)(x as Object[])[0]).ToArray();
            return input.Last();
        }

        public override string ToString()
        {
            return this.Solve().ToString();
        }

    }
}
