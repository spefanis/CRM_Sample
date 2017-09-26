using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace SampleComparer.Classes
{

    //This functionality is here to generate a random sentance to offer the second layer of authentication. This can be user to prevent replay attacks.
    class sentenceGenerator
    {

        //Generate a color sequence of 5 colors that the user has to repeat for authentication.
        //INPUT:
        //OUPUT: String to speak
        public string generateColorSequence()
        {
            string returnString = "";

            //Create array and add colors
            string[] MyArray = new string[7];
            MyArray[0] = "Red";
            MyArray[1] = "Blue";
            MyArray[2] = "Green";
            MyArray[3] = "Yellow";
            MyArray[4] = "Black";
            MyArray[5] = "Pink";
            MyArray[6] = "Orange";

            //We use the crypto to generate random number as system.random isn't very thread safe. (See remarks her - https://msdn.microsoft.com/en-us/library/system.random.aspx)
            RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider();
            //Randomise the array
            string[] MyRandomArray = MyArray.OrderBy(x => GetNextInt32(rnd)).ToArray();
            //Return thefirst random colors
            returnString = string.Format("Color sequence is {0}, {1}, {2}, {3}, {4}", MyRandomArray[0], MyRandomArray[1], MyRandomArray[2], MyRandomArray[3], MyRandomArray[4]);
            return returnString;
        }

        //Generate a phonetic sequence of 5 words that the user has to repeat for authentication.
        //INPUT:
        //OUPUT: String to speak
        public string generatePhoneticSequence()
        {
            string returnString = "";

            //Create array and add colors
            string[] MyArray = new string[7];
            MyArray[0] = "Alpha";
            MyArray[1] = "Bravo";
            MyArray[2] = "Charlie";
            MyArray[3] = "Delta";
            MyArray[4] = "Echo";
            MyArray[5] = "Foxtrot";
            MyArray[6] = "Golf";
            MyArray[7] = "Hotel";
            MyArray[8] = "India";
            MyArray[9] = "Juliet";
            MyArray[10] = "Kilo";
            MyArray[11] = "Lima";
            MyArray[12] = "Mike";
            MyArray[13] = "November";
            MyArray[14] = "Oscar";
            MyArray[15] = "Papa";
            MyArray[16] = "Quebec";
            MyArray[17] = "Romeo";
            MyArray[18] = "Sierra";
            MyArray[19] = "Tango";
            MyArray[20] = "Uniform";
            MyArray[21] = "Victor";
            MyArray[22] = "Whiskey";
            MyArray[23] = "X-ray";
            MyArray[24] = "Yankee";
            MyArray[25] = "Zulu";


            //We use the crypto to generate random number as system.random isn't very thread safe. (See remarks her - https://msdn.microsoft.com/en-us/library/system.random.aspx)
            RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider();
            //Randomise the array
            string[] MyRandomArray = MyArray.OrderBy(x => GetNextInt32(rnd)).ToArray();
            //Return thefirst random colors
            returnString = string.Format("Word sequence is {0}, {1}, {2}, {3}, {4}", MyRandomArray[0], MyRandomArray[1], MyRandomArray[2], MyRandomArray[3], MyRandomArray[4]);
            return returnString;
        }


        //Used to generate a random number
        static int GetNextInt32(RNGCryptoServiceProvider rnd)
        {
            byte[] randomInt = new byte[4];
            rnd.GetBytes(randomInt);
            return Convert.ToInt32(randomInt[0]);
        }

        //This generates a random sentance using the logic of sentances. Not used as they don't make sense
        //INPUT: 
        //OUPUT: String with sentance
        public string generateRandomSentence()
        {
            try
            {
                //Create arrays with strings
                string[] strNouns = { " time", "year", "people", "way", "day", "man", "thing", "woman", "life", "child", "world", "school", "state", "family", "student", "group", "country", "problem", "hand", "part", "place", "case", "week", "company", "system", "program", "question", "work", "government", "number", "night", "point", "home", "water", "room", "mother", "area", "money", "story", "fact", "month", "lot", "right", "study", "book", "eye", "job", "word", "business", "issue", "side", "kind", "head", "house", "service", "friend", "father", "power", "hour", "game", "line", "end", "member", "law", "car", "city", "community", "name", "president", "team", "minute", "idea", "kid", "body", "information", "back", "parent", "face", "others", "level", "office", "door", "health", "person", "art", "war", "history", "party", "result", "change", "morning", "reason", "research", "girl", "guy", "moment", "air", "teacher", "force", "education" };
                string[] strAdjectives = { "other", "new", "good", "high", "old", "great", "big", "American", "small", "large", "national", "young", "different", "black", "long", "little", "important", "political", "bad", "white", "real", "best", "right", "social", "only", "public", "sure", "low", "early", "able", "human", "local", "late", "hard", "major", "better", "economic", "strong", "possible", "whole", "free", "military", "TRUE", "federal", "international", "full", "special", "easy", "clear", "recent", "certain", "personal", "open", "red", "difficult", "available", "likely", "short", "single", "medical", "current", "wrong", "private", "past", "foreign", "fine", "common", "poor", "natural", "significant", "similar", "hot", "dead", "central", "happy", "serious", "ready", "simple", "left", "physical", "general", "environmental", "financial", "blue", "democratic", "dark", "various", "entire", "close", "legal", "religious", "cold", "final", "main", "green", "nice", "huge", "popular", "traditional", "cultural" };
                string[] strVerbs = { "fell", "walked", "lived", "went", "came", "busted", "hustled", "sneaked", "be", "have", "do", "say", "go", "can", "get", "would", "make", "know", "will", "think", "take", "see", "come", "could", "want", "look", "use", "find", "give", "tell", "work", "may", "should", "call", "try", "ask", "need", "feel", "become", "leave", "put", "mean", "keep", "let", "begin", "seem", "help", "talk", "turn", "start", "might", "show", "hear", "play", "run", "move", "like", "live", "believe", "hold", "bring", "happen", "must", "write", "provide", "sit", "stand", "lose", "pay", "meet", "include", "continue", "set", "learn", "change", "lead", "understand", "watch", "follow", "stop", "create", "speak", "read", "allow", "add", "spend", "grow", "open", "walk", "win", "offer", "remember", "love", "consider", "appear", "buy", "wait", "serve", "die", "send", "expect", "build", "stay", "fall", "cut", "reach", "kill", "remain" };
                string[] strPrepositions = { "to make a pie.", "for no apparent reason.", "because the sky is green.", "for a disease.", "to be able to make toast explode.", "to know more about archeology." };
                string[] strArticles = { "my", "the", "any", "a", "this", "that", "his", "her" };

                //Create a new instance of Random
                Random rnd = new Random();

                {
                    //Generate the random string
                    string resultString = "";
                    resultString += strArticles[rnd.Next(strArticles.Length)] + " ";
                    resultString += strAdjectives[rnd.Next(strAdjectives.Length)] + " ";
                    resultString += strNouns[rnd.Next(strNouns.Length)] + " ";
                    resultString += strVerbs[rnd.Next(strVerbs.Length)] + " ";
                    resultString += strPrepositions[rnd.Next(strPrepositions.Length)];

                    //Article adjective nound verb preposition

                    resultString = char.ToUpper(resultString[0]) + resultString.Substring(1);
                    return resultString;
                }
            }
            catch (Exception ex)
            {
                return ("generateRandomSentence - " + ex.ToString());
            }
        }

        //This will generate a random paragraph from the refrence text file
        //INPUT:
        //OUPUT: string
        public string RandomParagraph()
        {
            //List<string> file = Directory.GetFiles("1.txt").ToList();
            var text = File.ReadLines(@"Reference Files\1.txt").ToList();
            int count = text.Count();
            Random rnd = new Random();
            int skip = rnd.Next(0, count);
            string line = text.Skip(skip).First();
            return line;

        }

        //This will generate a random sentence from the refrence text file
        //INPUT:
        //OUPUT: string
        public string RandomSentence()
        {
            string paragraph = RandomParagraph();
            string[] sentences = Regex.Split(paragraph, @"(?<=[\.;!\?])\s+");
            Random rnd = new Random();
            int skip = rnd.Next(sentences.Count());
            string sentence = sentences[skip];
            return sentence;
        }
    }
}
