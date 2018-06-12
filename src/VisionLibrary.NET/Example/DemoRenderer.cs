using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ImageListViewDemo
{
    public class DemoRenderer : ImageListView.ImageListViewRenderer
    {
        /// <summary>
        /// Returns item size for the given view mode.
        /// </summary>
        public override Size MeasureItem(View view)
        {
            if (view == View.Thumbnails)
            {
                Size itemPadding = new Size(4, 4);
                Size sz = ImageListView.ThumbnailSize + ImageListView.ItemMargin + itemPadding + itemPadding;
                return sz;
            }
            else
                return base.MeasureItem(view);
        }
        /// <summary>
        /// Erases the background of the control.
        /// </summary>
        public override void DrawBackground(Graphics g, Rectangle bounds)
        {
            if (ImageListView.View == View.Thumbnails)
                g.Clear(Color.FromArgb(32, 32, 32));
            else
                base.DrawBackground(g, bounds);
        }
        /// <summary>
        /// Draws the specified item on the given graphics.
        /// </summary>
        public override void DrawItem(Graphics g, ImageListViewItem item, ItemState state, Rectangle bounds)
        {
            if (ImageListView.View == View.Thumbnails)
            {
                Rectangle itemBounds = bounds;
                // Black background
                using (Brush b = new SolidBrush(Color.Black))
                {
                    g.FillRoundedRectangle(b, bounds, 4);
                }
                // Background of selected items
                if ((state & ItemState.Selected) == ItemState.Selected)
                {
                    using (Brush b = new SolidBrush(Color.FromArgb(128, Color.SteelBlue)))
                    {
                        g.FillRoundedRectangle(b, bounds, 4);
                    }
                }
                // Gradient background
                using (Brush b = new LinearGradientBrush(bounds, Color.Transparent, Color.FromArgb(96, Color.SteelBlue), LinearGradientMode.Vertical))
                {
                    g.FillRoundedRectangle(b, bounds, 4);
                }
                // Light overlay for hovered items
                if ((state & ItemState.Hovered) == ItemState.Hovered)
                {
                    using (Brush b = new SolidBrush(Color.FromArgb(32, Color.SteelBlue)))
                    {
                        g.FillRoundedRectangle(b, bounds, 4);
                    }
                }
                // Border
                using (Pen p = new Pen(Color.SteelBlue))
                {
                    g.DrawRoundedRectangle(p, bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1, 4);
                }
                // Image
                Image img = item.ThumbnailImage;
                if (img != null)
                {
                    int x = bounds.Left + (bounds.Width - img.Width) / 2;
                    int y = bounds.Top + (bounds.Height - img.Height) / 2;
                    g.DrawImageUnscaled(item.ThumbnailImage, x, y);
                    // Image border
                    using (Pen p = new Pen(Color.SteelBlue))
                    {
                        g.DrawRectangle(p, x, y, img.Width - 1, img.Height - 1);
                    }
                }
            }
            else
                base.DrawItem(g, item, state, bounds);
        }

        /// <summary>
        /// Draws the selection rectangle.
        /// </summary>
        public override void DrawSelectionRectangle(Graphics g, Rectangle selection)
        {
            using (Brush b = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(128, Color.Black), Color.FromArgb(128, SystemColors.Highlight)))
            {
                g.FillRectangle(b, selection);
            }
            using (Pen p = new Pen(SystemColors.Highlight))
            {
                g.DrawRectangle(p, selection.X, selection.Y, selection.Width, selection.Height);
            }
        }
    }
}
