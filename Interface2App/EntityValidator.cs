using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Interface2App
{	
	/// <summary>
	/// To be filled
	/// </summary>
	public class EntityValidator : IDataErrorInfo
	{
		public string this[string property]
		{
			get
			{
				var propertyDescryptor = TypeDescriptor.GetProperties(this)[property];
				if(propertyDescryptor == null)
					return string.Empty;
				var results = new List<ValidationResult>();
				var result = Validator.TryValidateProperty(propertyDescryptor.GetValue(this), new ValidationContext(this, null, null) { MemberName = property }, results);
				if(!result)
					return results.First().ErrorMessage;
				return string.Empty;
			}	
		}
		[Browsable(false)]
		public string Error
		{
			get
			{
				var results = new List<ValidationResult>();
				var result = Validator.TryValidateObject(this, new ValidationContext(this, null, null), results, true);
				if(!result)
					return string.Join(Environment.NewLine, results.Select(e =>e.ErrorMessage));

				return null;

			}
		}
		[Browsable(false)]
		public bool IsValid=>string.IsNullOrEmpty(Error);
	}
}
