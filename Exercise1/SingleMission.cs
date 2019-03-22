using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
	public class SingleMission : IMission
	{ 
		private string name;
		//a function that represents a single mission.
		private Func<double, double> mission;

		public string Name
		{
			get { return name; }
		}

		public string Type
		{
			get { return "Single"; }
		}

		public SingleMission(Func<double, double> function, string name)
		{
			this.name = name;
			this.mission = function;
		}
		public event EventHandler<double> OnCalculate;

		public double Calculate(double value)
		{
			if (mission != null)
			{
				value = mission(value);
			}
			OnCalculate?.Invoke(this, value);
			return value;
		}
	}
}
