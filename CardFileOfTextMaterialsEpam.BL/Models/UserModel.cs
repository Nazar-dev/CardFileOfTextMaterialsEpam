﻿using System.Collections.Generic;

namespace CardFileOfTextMaterialsEpam.BL.Models {
	public class UserModel {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<int> CardIds { get; set; }
	}
}