using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeekARide.Models {
	public class Request {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int RequestId { get; set; }
		public virtual User Owner { get; set; }
		public virtual User User { get; set; }
		public string To { get; set; }
		public string From { get; set; }
		public DateTime StartTime { get; set; }
		public int Response { get; set; }
        public virtual TripInformation TripInformation { get; set; }
	}
}