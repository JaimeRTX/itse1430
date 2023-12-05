/*
 * ITSE 1430
 */
namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <inheritdoc />
        public Product Add ( Product product )
        { 
            if( product == null )
                throw new ArgumentNullException(nameof(product));
            

            ObjectValidator.Validate(product);

            var existing = FindByName(product.Name);

            if( existing != null )
            {
                throw new InvalidOperationException("Product Name Must be Unique");
            }

            try
            {
                //Emulate database by storing copy
                return AddCore(product);
            }
            catch(Exception ex) 
            {
                throw new InvalidOperationException("Add Failed", ex);
            }
  
        }

        /// <inheritdoc />
        public Product Get ( int id )
        {
            if ( id < 0 )
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID Must Be Greater Than 0");
            }
            return GetCore(id);
        }

        /// <inheritdoc />
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }

        /// <inheritdoc />
        public void Remove ( int id )
        {

            if( id <= 0 ) 
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID Must be Greater Than");
            }
            try
            {
                RemoveCore(id);
            }
            catch (Exception ex) 
            {
                throw new InvalidOperationException("Add Failed", ex);
            }
                
        }

        /// <inheritdoc />
        public void Update (int id, Product product )
        {
            if(id <= 0 )
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID ");
            }

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            ObjectValidator.Validate(product);

            //Get existing product
            var existing = FindByName(product.Name);
            if (existing != null && existing.Id != id)
            {
                throw new InvalidOperationException("Product Name Must be Unique");
            }
            existing = FindById(product.Id);
            if(existing == null)
            {
                throw new ArgumentException("Product Not Found", nameof(id));
            }
            try
            {
                UpdateCore(existing, product);
            }
            catch(Exception ex) 
            {
                throw new InvalidOperationException("Add Failed", ex);
            }
        }

        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract void UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );

        protected abstract Product FindByName ( string name );

        protected abstract Product FindById ( int id );
        #endregion
    }
}
