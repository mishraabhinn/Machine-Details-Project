﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GetMachineNameAssestNameLastestAssest.Model;

namespace GetMachineNameAssestNameLastestAssest.Service
{
	public class CsvReader
	{
		private string _csvFilePath;
		private string UserInput;

		public CsvReader(string csvFilePath, string userInput)
		{
			this._csvFilePath = csvFilePath;
			UserInput = userInput;
		}

		public List<MachineProperties> ReadAllMachines()
		{
			List<MachineProperties> machines = new List<MachineProperties>();
			
			using (StreamReader sr = new StreamReader(_csvFilePath))
			{
				// read header line
				sr.ReadLine();
				string csvLine;

				while ((csvLine = sr.ReadLine()) != null)
				{


					machines.Add(ReadMachineFromCsvLine(csvLine));
				}

			}

			return machines;
		}

		public MachineProperties ReadMachineFromCsvLine(string csvLine)
		{
			string[] parts = csvLine.Split(',');
			string machinename = parts[0];
			string assetname = parts[1];
			string series = parts[2];

			return new MachineProperties(machinename, assetname, series);
		}


	}
}
