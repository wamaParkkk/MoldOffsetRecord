namespace MoldOffsetRecord
{
    public enum Page
    {        
        MaintnancePage = 0,
        RecipePage = 1
    }

    class Define
    {
        public const int BUFSIZ = 512;                
                
        public static byte currentPage = 0;
        public static byte MaintCurrentPage = 0;
    }    
}
