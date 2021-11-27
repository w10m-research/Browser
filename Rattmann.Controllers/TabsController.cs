using Rattmann.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattmann.Controllers {
    public class TabsController {
        public TabsController() {
            this._tabs = new List<TabModel>();
        }

        public void NavigateTo(LocationModel location) {
            this._tabs[this.TabIndex].History.Add(location);
            this._tabs[this.TabIndex].HistoryIndex = this._tabs[this.TabIndex].History.Count;
        }

        public void GoForward(Int32 steps = 1) {
            this._tabs[this.TabIndex].HistoryIndex += steps;
        }

        public void GoBackwards(Int32 steps = 1) {
            this._tabs[this.TabIndex].HistoryIndex -= steps;
        }

        private List<TabModel> _tabs;
        public List<TabModel> Tabs {
            get {
                if (this._tabs.Count <= 0)
                    this._tabs.Add(new TabModel());
                return this._tabs;
            }
            set => this._tabs = value;
        }

        public Int32 TabIndex { get; set; }
    }
}
