using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Excercise_1
{

	public class FunctionsContainer
	{
		/*
		 * A default function. Will be assigned to a key, which does not exist in the container,when
		 * we will be asked to return a function of this key.
		 */
		static private readonly Func<double, double> DefaultFunction = value => value;
		
		private Dictionary<string, Func<double, double>> dictionaryOfFunctions = new Dictionary<string, Func<double, double>>();
		public Func<double, double> this[string key]
		{
			get
			{
				Func<double,double> value = null;
				if (dictionaryOfFunctions.TryGetValue(key, out value))
				{
					return value;
				}
				else
				{
					dictionaryOfFunctions[key] = DefaultFunction;
					return DefaultFunction;
				}
			}
			set
			{
				dictionaryOfFunctions[key] = value;
			}
		}
		public ICollection<String> getAllMissions()
		{
			return this.dictionaryOfFunctions.Keys;
		}
	}
}
