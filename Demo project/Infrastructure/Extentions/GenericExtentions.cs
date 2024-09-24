namespace Demo_project.Infrastructure.Extentions
{
    public static class GenericExtentions
    {
        public static object GetGenericValue<T>(this T data, string property)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (property == null)
            {
                throw new ArgumentNullException("property");
            }

            return data.GetType().GetProperty(property).GetValue(data);
        }
    }
}
