namespace AnimalWeb.Models
{
    public class commentsPicQue
    {
     

        public static string[] pictures = new string[]
        {
           @"\Assets\commentsPictures\man1.png",
           @"\Assets\commentsPictures\man2.png",
           @"\Assets\commentsPictures\man3.png",
           @"\Assets\commentsPictures\woman1.png",
           @"\Assets\commentsPictures\woman2.png",
           @"\Assets\commentsPictures\woman3.png"
        };
        

        public static string GetRandomUrlForImag()
        {
            Random random = new Random();
         int picNum = random.Next(pictures.Length);
            return pictures[picNum];

        }
    }
}
