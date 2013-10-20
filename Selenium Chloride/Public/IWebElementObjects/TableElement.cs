using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OpenQA.Selenium;

namespace Selenium_Chloride
{
    public class TableElement : PageElement
    {
        private DataTable _table = new DataTable();

        public TableElement(IBrowser browser, string name) : base(browser, name) 
        {
            _table = ToDataTable();
        }

        public DataTable Table 
        {
            get
            {
                if (_table.Rows.Count <= 0)
                {
                    _table = ToDataTable();
                }
                return _table;
            }
        }

        #region private methods
        private DataTable ToDataTable()
        {
            var table = new DataTable();
            var key = true;

            // Build columns
            var columns = base.IWebElement.FindElements(By.CssSelector("thead tr td"));
            if (columns.Count > 0)
            {
                key = false;

                foreach (var col in columns)
                {
                    table.Columns.Add(col.Text, typeof(IWebElement));
                }

                // Insert rows
                var rows = base.IWebElement.FindElements(By.CssSelector("tbody tr"));
                foreach (var row in rows)
                {
                    var items = row.FindElements(By.CssSelector("td"));

                    if (items.Count > 0 && items.Count <= table.Columns.Count)
                    {
                        var temp = table.NewRow();
                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            if (i < items.Count && items[i] != null)
                            {
                                temp[i] = (IWebElement) items[i];
                            }
                        }
                        table.Rows.Add(temp);
                    }
                }
            }

            columns = base.IWebElement.FindElements(By.CssSelector("thead tr th"));
            if (columns.Count > 0 && key)
            {
                key = false;
                foreach (var col in columns)
                {
                    table.Columns.Add(col.Text, typeof(IWebElement));
                }

                // Insert rows
                var rows = base.IWebElement.FindElements(By.CssSelector("tbody tr"));
                foreach (var row in rows)
                {
                    var items = row.FindElements(By.CssSelector("td"));

                    if (items.Count > 0 && items.Count <= table.Columns.Count)
                    {
                        var temp = table.NewRow();
                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            if (i < items.Count && items[i] != null)
                            {
                                temp[i] = (IWebElement) items[i];
                            }
                        }
                        table.Rows.Add(temp);
                    }
                }
            }

            if (key)
            {
                var cols = base.IWebElement.FindElements(By.CssSelector("tbody tr"));
                var data = new List<IWebElement>();
                foreach (var col in cols)
                {
                    var items = col.FindElements(By.CssSelector("td"));
                    table.Columns.Add(items[0].Text, typeof(IWebElement));
                    data.Add(items[1]);
                }

                var temp = table.NewRow();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    temp[i] = data[i];
                }
                table.Rows.Add(temp);
            }

            return table;
        }
        #endregion
    }
}
