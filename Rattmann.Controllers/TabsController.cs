using Rattmann.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattmann.Controllers {
    public class TabsController {
        public TabsController() {
            
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

        public void NewTab(TabModel tab) {
            this._tabs.Add(tab);
            this.TabIndex = this._tabs.Count;
        }

        private List<TabModel> _tabs = new List<TabModel>();
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
