using Nameless.Libraries.Rukia.RodentRevenge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Config = Nameless.Libraries.Rukia.RodentRevenge.Model.RodentMouseSettings;
namespace Nameless.Libraries.Rukia.RodentRevenge
{
    public class GameGrid
    {
        int ColumnCount;
        int RowCount;

        GameCell[,] Cells;

        public GameGrid(int colCount, int rowCount)
        {
            this.ColumnCount = colCount;
            this.RowCount = rowCount;
            Cells = new GameCell[this.RowCount, this.ColumnCount];
        }


        public void Draw(Canvas InkCanvas)
        {
            Size cellSize = new Size(InkCanvas.RenderSize.Width / (double)ColumnCount, InkCanvas.RenderSize.Height / (double)RowCount);
            ResourceDictionary rd = (Application.Current.Resources as ResourceDictionary).MergedDictionaries[0] as ResourceDictionary;
            DrawBorders(InkCanvas, rd, cellSize);
            DrawMouse(InkCanvas, rd, cellSize);
        }

        private void DrawMouse(Canvas InkCanvas, ResourceDictionary rd, Size gridSize)
        {
            ContentControl ctrl = new ContentControl();
            Style style = (Style)rd[Config.MOUSE_STYLE];
            ctrl.Style = style;
            ctrl.Width = gridSize.Width;
            ctrl.Height = gridSize.Height;
            ctrl.Name = "C10_10";
            ctrl.SetValue(Canvas.LeftProperty, 10 * gridSize.Width);
            ctrl.SetValue(Canvas.TopProperty, 10 * gridSize.Height);
            InkCanvas.Children.Add(ctrl);
        }

        private void DrawBorders(Canvas InkCanvas, ResourceDictionary rd, Size gridSize)
        {
            ContentControl ctrl;
            Style style = (Style)rd[Config.BOUND_STYLE];
            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColumnCount; j++)
                    if (i == 0 || i == RowCount - 1)
                    {
                        ctrl = new ContentControl();
                        ctrl.Style = style;
                        ctrl.Width = gridSize.Width;
                        ctrl.Height = gridSize.Height;
                        ctrl.Name = "C"+i.ToString() + "_" + j.ToString();
                        ctrl.SetValue(Canvas.LeftProperty, i * gridSize.Width);
                        ctrl.SetValue(Canvas.TopProperty, j * gridSize.Height);
                        InkCanvas.Children.Add(ctrl);
                        //Cells[i, j] = ctrl.InitCell();
                    }
                    else
                    {
                        if (j == 0 || j == ColumnCount - 1)
                        {
                            ctrl = new ContentControl();
                            ctrl.Style = style;
                            ctrl.Width = gridSize.Width;
                            ctrl.Height = gridSize.Height;
                            ctrl.Name = "C" + i.ToString() + "_" + j.ToString();
                            ctrl.SetValue(Canvas.LeftProperty, i * gridSize.Width);
                            ctrl.SetValue(Canvas.TopProperty, j * gridSize.Height);
                            InkCanvas.Children.Add(ctrl);
                            //  Cells[i, j] = ctrl.AddBound();
                        }
                    }
        }

    }
}
