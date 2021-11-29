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
            this.Tabs[this.TabIndex].History.Add(location);
            this.Tabs[this.TabIndex].HistoryIndex = this._tabs[this.TabIndex].History.Count - 1;
        }

        public void GoForward(Int32 steps = 1) {
            this.Tabs[this.TabIndex].HistoryIndex += steps;
        }

        public void GoBackwards(Int32 steps = 1) {
            this.Tabs[this.TabIndex].HistoryIndex -= steps;
        }

        public void NewTab(TabModel tab) {
            this.Tabs.Add(tab);
            this.TabIndex = this._tabs.Count - 1;
        }

        public void CloseTab(TabModel tab) {
            this.Tabs.Remove(tab);
            this.TabIndex = this._tabs.Count - 1;
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

        public Int32 TabIndex { get; set; } = 0;
    }
}
