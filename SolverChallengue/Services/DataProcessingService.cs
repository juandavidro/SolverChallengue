using SolverChallengue.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverChallengue.Services
{
    public class DataProcessingService : IDataProcessingService
    {
        public List<int> getInputData(FileModel inputFile) 
        {
            List<int> currentData = new List<int>();
            var result = new StringBuilder();
            using (var reader = new StreamReader(inputFile.FormFile.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    result.AppendLine(reader.ReadLine());
                    var currData = result.ToString().Replace("\r\n", string.Empty).Trim();
                    if(currData != "")
                    {
                        currentData.Add(int.Parse(currData));
                    }
                    result.Clear();
                }
            }
            return currentData;
        }

        public List<int> getOutPutData(List<int> inputData)
        {
            List<int> outPutData = new List<int>();            
            int days = inputData[0];
            int currentIndex = 1;
            List<int> currentDay = new List<int>();

            for (int j = 0; j < days; j++)
            {
                int wi = inputData[currentIndex];
                for (int i = 0; i < wi; i ++ )
                {
                    currentIndex++;
                    currentDay.Add(inputData[currentIndex]);
                }
                currentIndex++;
                currentDay.Sort();
                outPutData.Add(maxTravels(currentDay));
                currentDay.Clear();
            }
            return outPutData;
        }

        public string getOutPutString(List<int> inputData)
        {
            string returnStr = "";
            for (int i = 1; i <= inputData.Count(); i++ )
            {
                returnStr = returnStr + "Case #" + i.ToString() + ": " + inputData[i-1].ToString() + "\r\n";
            }
            return returnStr;
        }

        public static int maxTravels(List<int> _dailydata)
        {
            var dailydata = _dailydata;
            int boxCount = dailydata.Count();
            int maxTravels = 0;
            int peek = 2;

            while (boxCount > 0)
            {
                if (dailydata[boxCount - 1] >= 50)
                {
                    dailydata.Remove(dailydata[boxCount - 1]);
                    boxCount--;
                }                
                else
                {
                    while ( (dailydata[boxCount - 1] * peek) < 50)
                        peek++;

                    dailydata.Remove(dailydata[boxCount - 1]);
                    boxCount--;
                    for (int i =0; i < peek - 1; i++)
                    {
                        dailydata.Remove(dailydata[0]);
                        boxCount--;
                    }
                }

                if (boxCount >= 1 && dailydata[boxCount - 1] * boxCount < 50)
                {
                    dailydata.Clear();
                    boxCount = 0;
                }

                maxTravels++;
            }

            return maxTravels;
        }
    }
}
