namespace ImageLazyLoadingSystem
{
    public class ImageLazyLoadingProgram
    {
        public static void Main()
        {
            LazyImageLoader imageLoader = new LazyImageLoader();

            // Access ImageData property (lazy initialization)
            Console.WriteLine("Accessing image data...");
            byte[] imageData = imageLoader.ImageData;

            // Image data is already loaded (no further loading)
            Console.WriteLine("Accessing image data again...");
            imageData = imageLoader.ImageData;
        }
    }

    public class LazyImageLoader
    {
        private byte[] imageData;
        private bool isLoaded = false;

        public byte[] ImageData
        {
            get
            {
                if (!isLoaded)
                {
                    Console.WriteLine("Loading image data...");
                    imageData = LoadImageDataFromDisk();
                    isLoaded = true;
                }
                return imageData;
            }
        }

        private byte[] LoadImageDataFromDisk()
        {
            // Simulate loading image data from disk (e.g., file or database)
            return new byte[] { 0xFF, 0xD8, 0xFF, 0xE0, 0x00, 0x10, 0x4A, 0x46, 0x49, 0x46 };
        }
    }

}
