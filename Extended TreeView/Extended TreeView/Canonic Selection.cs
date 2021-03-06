﻿using System.Collections;

namespace CustomControls
{
    public class CanonicSelection
    {
        public CanonicSelection(IList itemList)
        {
            this.ItemList = itemList;
            this.AllItemsCloneable = true;
            this.RecordCount = 0;
        }

        public object DraggedItemParent { get; set; }
        public IList ItemList { get; private set; }
        public bool AllItemsCloneable { get; set; }
        public int RecordCount { get; set; }
    }
}
