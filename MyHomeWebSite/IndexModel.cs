namespace MyHomeWebSite.Model
{
    public class IndexModel : IModel<IndexModel>
    {
        public IndexModel model { get; set; }
        public int Tax { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }

        public string add()
        {
            return Tax.ToString();
        }
    }

    public static class IndexModelExtend
    {
        public static DateTime TranDate<T>(this IModel<T> model)
        {
            DateTime date = DateTime.Parse(model.Name);
            return date;
        }


        public static bool Success<T>(this IModel<T> model, Func<T, int> fun)
        {
            return true;
        }
    }

    public class ProdModel : IModel<ProdModel>
    {
        public ProdModel model { get; set; }
        public int Price { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public interface IModel<T>
    {
        T model { get; set; }
        string Id { get; set; }
        string Name { get; set; }

    }

    public class TestModel<T> : IModel<T>
    {
        public T model { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SetID { get; set; }
        public List<T> list { get; set; }


    }
}
