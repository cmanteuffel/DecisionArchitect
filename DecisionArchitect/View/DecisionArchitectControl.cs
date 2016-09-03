/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Antonis Gkortzis (University of Groningen)   
    Mark Hoekstra (University of Groningen)
    Mathieu Kalksma (University of Groningen)
*/

using System;
using System.Reflection;
using System.Windows.Forms;
using DecisionArchitect.Utilities;
using EAFacade.Model;

namespace DecisionArchitect.View
{
    public class DecisionArchitectControl : UserControl
    {
        private const double SelectionLuminosityFactor = .65;
        private const double SelectionSaturationFactor = .55;


        /********************************************************************************************
         ******************************************************************************************** 
        ** Auxillery methods
        ******************************************************************************************** 
        ********************************************************************************************/

        // Color the cell according to the State
        protected void ColorCellAccordingToState(DataGridViewCell cell, string state)
        {
            cell.Style.BackColor = DecisionStateColor.ConvertStateToColor(state);
            HSLColor hsl = DecisionStateColor.ConvertStateToColor(state);
            hsl.Luminosity = (hsl.Luminosity * SelectionLuminosityFactor);
            hsl.Saturation = (hsl.Saturation * SelectionSaturationFactor);
            cell.Style.SelectionBackColor = hsl;
        }

        protected void ColorRowAccordingToState(DataGridViewRow row, string state)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                ColorCellAccordingToState(cell, state);
            }
        }

        protected void FixNestedProperty(DataGridView grid, DataGridViewCellFormattingEventArgs e)
        {
            var row = grid.Rows[e.RowIndex];
            try
            {
                if ((row.DataBoundItem != null) &&
                    (grid.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
                {
                    e.Value = BindProperty(
                        row.DataBoundItem,
                        grid.Columns[e.ColumnIndex].DataPropertyName
                        );
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        /// <summary>
        ///     Require for nested property binding.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected string BindProperty(object property, string propertyName)
        {
            string retValue = "";

            if (propertyName.Contains("."))
            {
                string leftPropertyName = propertyName.Substring(0, propertyName.IndexOf(".", StringComparison.Ordinal));
                PropertyInfo[] arrayProperties = property.GetType().GetProperties();

                foreach (PropertyInfo propertyInfo in arrayProperties)
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        retValue = BindProperty(
                            propertyInfo.GetValue(property, null),
                            propertyName.Substring(propertyName.IndexOf(".", StringComparison.Ordinal) + 1));
                        break;
                    }
                }
            }
            else
            {
                Type propertyType = property.GetType();
                PropertyInfo propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }

            return retValue;
        }

    }
}
