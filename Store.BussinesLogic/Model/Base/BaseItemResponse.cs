namespace Store.BussinesLogic.Model.Base
{
    public sealed class BaseItemResponse<TItem>
    {
        public string Message { get; set; }

        public TItem Item { get; set; }

        public static BaseItemResponse<TItem> CreateResponse(TItem element)
        {
            return new BaseItemResponse<TItem> { Item = element };
        }
    }
}
