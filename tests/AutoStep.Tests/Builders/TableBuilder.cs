﻿using System;
using AutoStep;
using AutoStep.Elements;

namespace AutoStep.Tests.Builders
{
    public class TableBuilder : BaseBuilder<TableElement>
    {
        public TableBuilder(int line, int column, bool relativeToTextContent = false)
            : base(relativeToTextContent)
        {
            Built = new TableElement
            {
                SourceLine = line,
                SourceColumn = column
            };
        }

        public TableBuilder Headers(int lineNo, int column, params (string headerName, int startColumn, int endColumn)[] headers)
        {
            Built.Header.SourceLine = lineNo;
            Built.Header.SourceColumn = column;

            foreach(var item in headers)
            {
                Built.Header.AddHeader(new TableHeaderCellElement
                {
                    HeaderName = item.headerName,
                    SourceLine = lineNo,
                    SourceColumn = item.startColumn,
                    EndColumn = item.endColumn
                });
            }

            return this;
        }

        public TableBuilder Row(int lineNo, int column, params (string rawValue, int startColumn, int endColumn, Action<CellBuilder> cfg)[] cells)
        {
            var row = new TableRowElement
            {
                SourceLine = lineNo,
                SourceColumn = column  
            };

            foreach(var item in cells)
            {
                var cell = new CellBuilder(item.rawValue, lineNo, item.startColumn, item.endColumn);

                if(item.cfg is object)
                {
                    item.cfg(cell);
                }
                else if(item.rawValue is string)
                {
                    cell.Word(item.rawValue, item.startColumn);
                }
                
                row.AddCell(cell.Built);
            }

            Built.AddRow(row);

            return this;
        }
    }
}
