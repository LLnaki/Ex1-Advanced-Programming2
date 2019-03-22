using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{

	public class ComposedMission : IMission
	{
		//A list of missions, which together represent a composed mission.
		private List<Func<double, double>> missions = new List<Func<double,double>>();
		private string name;
		public string Name
		{
			get { return name; }
		}

		public string Type
		{
			get { return "Composed"; }
		}
		public event EventHandler<double> OnCalculate;

		public ComposedMission(string name)
		{
			this.name = name;
		}
		public ComposedMission Add(Func<double, double> function)
		{
			missions.Add(function);
			return this;
		}
		public double Calculate(double value)
		{
			/*
			 * Performing a composed mission - performing each separated mission in the order in which
			 * they were added to this ComposedMission.
			 */
			foreach(var mission in missions)
			{
				value = mission(value);
			}
			OnCalculate?.Invoke(this, value);
			return value;
		}
	}
}
