using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattmann.Models {
    public class TabModel {
        public Int32 HistoryIndex { get; set; } = 0;

        public List<LocationModel> History { get; set; } = new List<LocationModel>() {
            new LocationModel() {
                Title = "New tab",
                Favicon = null
            }
        };
    }
}
