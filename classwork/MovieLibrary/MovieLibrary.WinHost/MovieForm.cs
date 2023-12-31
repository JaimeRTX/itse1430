﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLibrary.WinHost
{
    public partial class MovieForm : Form
    {
        public MovieForm ()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the New Movie
        /// </summary>
        public Movie Movie { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (Movie != null)
            {
                Text = "Edit Movie";
                _txtTitle.Text = Movie.Title;
                _txtDescription.Text = Movie.Description;
                _txtGenre.Text = Movie.Genre;

                _cbRating.Text = Movie.Rating?.Name;
                _txtReleaseYear.Text = Movie.ReleaseYear.ToString();
                _txtRunLength.Text = Movie.RunLength.ToString();

                _chkBlackWhite.Checked = Movie.IsBlackAndWhite;
            }

            ValidateChildren();
        }

        private void OnSave ( object sender, EventArgs e )
        {
            //Validate and abort if necesarry
            if (!ValidateChildren())
            {
                DialogResult = DialogResult.None;
                return;
            }

            var button = sender as Button;
            var movie = new Movie();

            //Populate from the UI
            movie.Title = _txtTitle.Text;
            movie.Description = _txtDescription.Text;
            movie.Genre = _txtGenre.Text;

            movie.Rating = new Rating(_cbRating.Text);
            movie.ReleaseYear = GetInt32(_txtReleaseYear, 0);
            movie.RunLength = GetInt32(_txtRunLength, -1);

            movie.IsBlackAndWhite = _chkBlackWhite.Checked;

            //Validate
           
            //if (!movie.TryValidate(out var error))
            if(!ObjectValidator.TryValidate(movie, out var results))
            {
                var error = results.First();
                MessageBox.Show(this, error.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            Movie = movie;
            //DialogResult = DialogResult.OK;
            //Close();
        }

        private void OnCancel ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private int GetInt32 ( Control control, int defaultValue )
        {
            if (Int32.TryParse(control.Text, out var value))
            {
                return value;
            }

            return defaultValue;
        }

        private void MovieForm_Load ( object sender, EventArgs e )
        {

        }

        private void OnValidateTitle ( object sender, CancelEventArgs e )
        {
            if (String.IsNullOrEmpty(_txtTitle.Text))
            {
                _errors.SetError(_txtTitle, "Title Is Required");
                e.Cancel = true;
            } else
            {
                _errors.SetError(_txtTitle, "");
            }

        }

        private void OnValidateReleaseYear ( object sender, CancelEventArgs e )
        {
            var value = GetInt32(_txtReleaseYear, 1);
            if (value < 1900)
            {
                _errors.SetError(_txtReleaseYear, "Release Year must be at least 1900");
                e.Cancel = true;
            } else
            {
                _errors.SetError(_txtReleaseYear, "");
            }

        }

        private void OnValidateRunLength ( object sender, CancelEventArgs e )
        {

            var value = GetInt32(_txtRunLength, 1);
            if (value < 0)
            {
                _errors.SetError(_txtRunLength, "Run Length Must Be >= 0");
                e.Cancel = true;
            } else
            {
                _errors.SetError(_txtRunLength, "");
            }

        }

        private void OnValidateRating ( object sender, CancelEventArgs e )
        {
            if (String.IsNullOrEmpty(_cbRating.Text))
            {
                _errors.SetError(_cbRating, "Rating Is Required");
                e.Cancel = true;
            } else
            {
                _errors.SetError(_cbRating, "");
            }

        }

        private void _txtTitle_TextChanged ( object sender, EventArgs e )
        {

        }
    }
}
