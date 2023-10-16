using Nameless.Libraries.Evangelion.Rei;
using Nameless.Libraries.Yggdrasil.Frau.Threading;
using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Word_Generator
{

    public class WordCombiner : NamelessObject, IPoolThread
    {

        public const int MAX_NUMBER_OF_THREADS = 35;

        PoolThread PoolBgTask_Combiner;




        /// <summary>
        /// The list of word creted by the word combiner
        /// </summary>
        public List<Word> Words;
        /// <summary>
        /// Gets the total number of combinations
        /// </summary>
        public int Combinations;
        /// <summary>
        /// Gets the total number of combinations
        /// </summary>
        public int Permutations;
        /// <summary>
        /// Gets the size of the word
        /// </summary>
        byte WordSize;
        /// <summary>
        /// Available characters to create a word:
        /// </summary>
        Char[] Characters;
        /// <summary>
        /// Create a list of words from an input of characters and a word size
        /// </summary>
        /// <param name="langle">Tha language manager</param>
        /// <param name="charIndex">The array of character indexes</param>
        /// <param name="wordSize">The size of the word</param>
        public WordCombiner(Babel langle, Char[] characters, byte wordSize)
        {
            this.Words = new List<Word>();
            this.WordSize = wordSize;
            this.Characters = characters;
            this.Combinations = CalculateCombinations(characters.Length, wordSize);
            this.Permutations = (int)Math.Pow(wordSize, wordSize);
        }
        /// <summary>
        /// Calculates the number of words that can be combined with
        /// a specific number of characters to choose and the word size.
        /// </summary>
        /// <param name="n">The number of characters to choose from</param>
        /// <param name="r">The size of the word</param>
        /// <returns>The total number of available combinations</returns>
        private int CalculateCombinations(int n, byte r)
        {
            int nF = Factorial(n),
                n_rF = Factorial(n - r);
            return nF / n_rF;
        }
        /// <summary>
        /// Calculates the factorial for an int number
        /// </summary>
        /// <param name="n">The number to calculate the factorial</param>
        /// <returns>The factorial of the number</returns>
        private int Factorial(int n)
        {
            int val = 1;
            for (int i = 1; i <= n; i++)
                val *= i;
            return val;
        }
        /// <summary>
        /// Init the combination process
        /// </summary>
        public void Combine()
        {
            int threadFactor = MAX_NUMBER_OF_THREADS;
            if (MAX_NUMBER_OF_THREADS >= this.Combinations)
                threadFactor = this.Combinations - 2;
            if (this.Combinations <= threadFactor)
            {
                IntegerNumber startNumber = new IntegerNumber(this.WordSize);
                CreateDigits(ref startNumber);
                Word[] words = this.Combine(startNumber, new int[] { 0, this.Combinations });
                FillWords(words);
            }
            else
            {
                this.PoolBgTask_Combiner = new PoolThread();
                this.PoolBgTask_Combiner.ReportingTaskProgress += ReportTask;
                this.PoolBgTask_Combiner.TaskIsFinished += TaskIsFinished;
                this.InitThreads();
                //this.PoolBgTask_Combiner =
                //    new PoolBgTask<int, Word>();
                //CreateBGTask((int)((double)this.Combinations / threadFactor),
                //    (int)((double)this.Permutations / threadFactor));
            }

            while (!this.PoolBgTask_Combiner.TaskReady) { }

            
        }
        /// <summary>
        /// Create the word size digits
        /// </summary>
        /// <param name="num">The number to edit</param>
        /// <param name="baseNum">The base number</param>
        private void CreateDigits(ref IntegerNumber num)
        {
            int digSize = this.WordSize - (num.Digits.Count - 1);
            for (int k = 1; k < digSize; k++)
                num.Digits.Add(0);
        }
        /// <summary>
        /// Create the list of background tasks
        /// </summary>
        /// <param name="frameSize">The size of the background frame size</param>
        private void CreateBGTask(int frameSize, int permframeSize)
        {
            //BgTask<int, Word> bgTask;
            //for (int i = 0; i < MAX_NUMBER_OF_THREADS; i++)
            //{
            //    if (i == MAX_NUMBER_OF_THREADS - 1)
            //        bgTask = new BgTask<int, Word>(new int[] { frameSize * i, this.Combinations, permframeSize * i, permframeSize * (i + 1) }, Combiner_DoWork, Combiner_WorkCompleted);
            //    else
            //        bgTask = new BgTask<int, Word>(new int[] { frameSize * i, frameSize * (i + 1), permframeSize * i, permframeSize * (i + 1) }, Combiner_DoWork, Combiner_WorkCompleted);
            //    this.PoolBgTask_Combiner.Add(bgTask, false);
            //}
        }

        /// <summary>
        /// Do the combination work
        /// </summary>
        /// <param name="input">The start and end index of the combination frame</param>
        private Word[] Combiner_DoWork(int[] input, object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (input != null && input.Length == 4)
            {
                IntegerNumber startNumber = new IntegerNumber(this.WordSize);
                startNumber.Set(input[2].ToString(), 10);
                CreateDigits(ref startNumber);
                return Combine(startNumber, input);
            }
            else
                return new Word[0];
        }
        /// <summary>
        /// Fill the list of words once the process has finished
        /// </summary>
        private void Combiner_WorkCompleted(Word[] input, object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            FillWords(input);
        }
        /// <summary>
        /// Fill the list of words with a collection of words
        /// </summary>
        /// <param name="words">The collection of words to fill the list of words generated</param>
        private void FillWords(Word[] words)
        {
            foreach (Word w in words)
                this.Words.Add(w);
        }
        /// <summary>
        /// Combine a word starting and ending from an specific 
        /// combination
        /// </summary>
        /// <param name="number">The combination start number</param>
        /// <param name="endNumber">The combination end number</param>
        private Word[] Combine(IntegerNumber number, int[] frame)
        {
            List<Word> listOfWords = new List<Word>();
            Word w;
            Boolean HasRepetition;
            byte[] indexes;
            int countCombine = frame[0],
                countPermutation = frame[2];
            do
            {
                indexes = number.Digits.ToArray();
                w = new Word(indexes, this.Characters);
                HasRepetition = w.CheckRepetition(indexes);
                if (!HasRepetition)
                {
                    w.GetMeaning();
                    if (w.HasMeaning)
                        listOfWords.Add(w);
                    countCombine++;
                }
                countPermutation++;
                number.Next();
            } while (countCombine < frame[1] && countPermutation <= frame[3]);
            return listOfWords.ToArray();
        }


        public void InitThreads()
        {
            
            //for (int i = 0; i < MAX_NUMBER_OF_THREADS; i++)
            //{
            //    if (i == MAX_NUMBER_OF_THREADS - 1)
            //        bgTask = new BgTask<int, Word>(new int[] { frameSize * i, this.Combinations, permframeSize * i, permframeSize * (i + 1) }, Combiner_DoWork, Combiner_WorkCompleted);
            //    else
            //        bgTask = new BgTask<int, Word>(new int[] { frameSize * i, frameSize * (i + 1), permframeSize * i, permframeSize * (i + 1) }, Combiner_DoWork, Combiner_WorkCompleted);
            //    this.PoolBgTask_Combiner.Add(bgTask, false);
            //}
        }

        public void ReportTask(IEnumerable<FrauThread> threads)
        {
            //throw new NotImplementedException();
        }

        public object TaskIsFinished(object[] input)
        {
            this.Words.OrderBy(x => x.ToString());
            return null;
        }
    }
}
