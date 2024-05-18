using Microsoft.AspNetCore.Components.Forms;

namespace WebPage.Components.Pages
{
    public partial class LoadImage
    {
        private IBrowserFile selectedFile;

        private void HandleSelectedFile(InputFileChangeEventArgs e)
        {
            // Get the selected file from the input event
            selectedFile = e.File;
        }

        private async Task LoadImage2()
        {
            if (selectedFile != null)
            {
                try
                {
                    // Allocate a buffer for the file data
                    var buffer = new byte[selectedFile.Size];

                    // Read the file data into the buffer
                    await selectedFile.OpenReadStream().ReadAsync(buffer);

                    // Here you can process the image as needed
                    // For example, you could save the buffer to a file or display the image in the UI
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during file reading
                    Console.WriteLine($"Error loading image: {ex.Message}");
                }
            }
            else
            {
                // Handle the case where no file was selected
                Console.WriteLine("No file selected.");
            }
        }
    }
}