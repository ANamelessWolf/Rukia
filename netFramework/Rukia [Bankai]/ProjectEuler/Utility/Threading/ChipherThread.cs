
using Nameless.Libraries.Yggdrasil.Frau.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility.Threading
{
    public class ChipherThread : FrauThread
    {
        /// <summary>
        /// The list of asscii letters
        /// </summary>
        Char[] ASCII_LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
        /// <summary>
        /// The list of asscii letters as integer values
        /// </summary>
        int[] ASSCII_LETTERS_VALUES;
        /// <summary>
        /// The encrypted message
        /// </summary>
       public static int[] EncryptedMessage;
        /// <summary>
        /// The message decrypted
        /// </summary>
        public String DecryptedMessage { get { return Decrypt(); } }
        /// <summary>
        /// The encryption key
        /// </summary>
        public Char[] Key { get { return (Result as Object[])[1] as Char[]; } }
        /// <summary>
        /// The encryption key
        /// </summary>
        public double Ratio { get { return (double)(Result as Object[])[0]; } }
        /// <summary>
        /// Decrypt an encrypted message with the XOR method, and a given key
        /// </summary>
        /// <param name="EncryptedMessage">The encrypted message</param>
        /// <param name="Key">The key used to decrypt</param>
        /// <returns>The decrypted message</returns>
        private string Decrypt()
        {
            char[] decryptedMsg = Decrypt(EncryptedMessage, this.Key).Select<int, char>(x => (char)x).ToArray();
            return new String(decryptedMsg);
        }
        /// <summary>
        /// Decrypt an encrypted message with the XOR method, and a given key
        /// </summary>
        /// <param name="EncryptedMessage">The encrypted message</param>
        /// <param name="Key">The key used to decrypt</param>
        /// <returns>The decrypted message</returns>
        public static int[] Decrypt(int[] EncryptedMessage, char[] Key)
        {
            //  Key = new Char[] { 'g', 'o', 'd' };
            int[] decryptedMsg = new int[EncryptedMessage.Length];
            int keySize = Key.Length;
            for (int i = 0, j = 0; i < decryptedMsg.Length; i++, j++)
            {
                if (j == keySize)
                    j = 0;
                decryptedMsg[i] = EncryptedMessage[i] ^ Key[j];
            }
            //String msg = new String(decryptedMsg.Select<int, char>(x => (char)x).ToArray());
            return decryptedMsg;
        }
        /// <summary>
        /// Creates a new Cipher
        /// </summary>
        /// <param name="encryptedMsg">The encrypted message</param>
        public ChipherThread(String[] encryptedMsg, String[] keys)
        {
            this.ASSCII_LETTERS_VALUES = ASCII_LETTERS.Select<Char, int>(x => (int)x).ToArray();
            EncryptedMessage = encryptedMsg.Select<String, int>(x => int.Parse(x)).ToArray();
            this.InputData = new Object[] { EncryptedMessage, keys.Select<String, Char[]>(x => x.ToCharArray()).ToArray() };
            this.Goal = keys.Length;
            this.ReportProgress = false;
        }
        /// <summary>
        /// Prints the current cipher progress
        /// </summary>
        public override void ReportProgressTask(object bgWorker, System.ComponentModel.ProgressChangedEventArgs e)
        {
            Console.WriteLine(this.ToString());
        }
        /// <summary>
        /// Do the current background cipher work
        /// </summary>
        public override void DoWorkAction(object bgWorker, System.ComponentModel.DoWorkEventArgs e)
        {
            Object[] input = e.Argument as Object[];
            int[] eMsg = input[0] as int[];
            Char[][] keys = input[1] as Char[][];
            int[] result;
            double cRatio = 0, nRatio;
            for (int i = 0; i < keys.Length; i++)
            {
                result = Decrypt(eMsg, keys[i]);
                this.Current++;
                //this.Current *= 0.9d;
                if (this.ReportProgress)
                    (bgWorker as System.ComponentModel.BackgroundWorker).ReportProgress((int)this.Progress);
                nRatio = (double)result.Where(x => ASSCII_LETTERS_VALUES.Contains(x)).Count() / (double)eMsg.Length;
                if (nRatio > cRatio)
                {
                    e.Result = new Object[] { nRatio, keys[i] };
                    cRatio = nRatio;
                }
            }
            Object[] res = e.Result as Object[];
            this.Result = res;
            this.Result = new Object[] { res[0], res[1], DecryptedMessage };
        }
        /// <summary>
        /// Gets the cipher result
        /// </summary>
        public override void WorkTask_Completed(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //this.Current = this.Goal;
            //Object[] res = e.Result as Object[];
            //this.Result = res;
            //String s = DecryptedMessage;
            //this.Result = new Object[] { res[0], res[1], s };
           // Console.WriteLine("PID: {0} Work complete!!!", this.PID);
        }
    }
}
