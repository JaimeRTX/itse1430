/*
 * ITSE 1430
 */
using Nile.Stores.Sql;

namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm ()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            _gridProducts.AutoGenerateColumns = false;

            var connString = Program.GetConnectionString("ProductDatabase");
            UpdateList();
        }

        #region Event Handlers

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductAdd ( object sender, EventArgs e )
        {
            var child = new ProductDetailForm("Product Details");
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                _database.Add(child.Product);
            }
            catch(InvalidOperationException)
            {
                MessageBox.Show(this, "Product Already Added In", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            catch (ArgumentException)
            {
                MessageBox.Show(this, "Product Can't Be Added", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, ex.Message, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateList();
        }

        private void OnProductEdit ( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show("No products available.");
                return;
            };

            EditProduct(product);
        }

        private void OnProductDelete ( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
                return;

            DeleteProduct(product);
        }

        private void OnEditRow ( object sender, DataGridViewCellEventArgs e )
        {
            var grid = sender as DataGridView;

            //Handle column clicks
            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Product;

            if (item != null)
                EditProduct(item);
        }

        private void OnKeyDownGrid ( object sender, KeyEventArgs e )
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var product = GetSelectedProduct();
            if (product != null)
                DeleteProduct(product);

            //Don't continue with key
            e.SuppressKeyPress = true;
        }

        private void OnAboutBox ( object sender, EventArgs e )
        {
            var about = new AboutBox();
            about.ShowDialog();
        }

        #endregion

        #region Private Members

        private void DeleteProduct ( Product product )
        {
            //Confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?",
                                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //Delete product
            try
            {
                _database.Remove(product.Id);
                UpdateList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditProduct ( Product product )
        {
            var child = new ProductDetailForm("Product Details");
            child.Product = product;

            do
            {

                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    _database.Update(product.Id, child.Product);
                    UpdateList();
                    break;

                } 
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Save product
                UpdateList();
            } while (true);
        }

        private Product GetSelectedProduct ()
        {
            if (_gridProducts.SelectedRows.Count > 0)
                return _gridProducts.SelectedRows[0].DataBoundItem as Product;

            return null;
        }

        private void UpdateList ()
        {
            IEnumerable<Product> products = null;
            try
            {
                _bsProducts.DataSource = _database.GetAll();
                products = from m in products orderby m.Name ascending select m;
            } 
            catch
            {
                MessageBox.Show(this, "Unable To Retrive the Inventory", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private readonly IProductDatabase _database = new SqlProjectDatabase(Program.GetConnectionString("ProductDatabase"));
        #endregion
    }
}
