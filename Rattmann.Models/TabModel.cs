using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattmann.Models {
    public class TabModel {
        public Int32 HistoryIndex { get; set; } = 0;

        private List<LocationModel> _history = new List<LocationModel>();
        public List<LocationModel> History {
            get {
                // If empty return new tab page
                if (this._history.Count <= 0)
                    return new List<LocationModel>() {
                        new LocationModel() {
                            Title = "New tab",
                            Favicon = null
                        }
                    };

                return this._history;
            }
            set => this._history = value;
        }
    }
}
