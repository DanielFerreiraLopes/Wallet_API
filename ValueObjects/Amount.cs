namespace Wallet_API.ValueObjects
{
    public class Amount
    {
        public float Value { get; set; }
        public Amount(float value)
        {
            if (value < 0)
            {
                throw new Exception("Valor Invalido");
            }

            this.Value = value;
        }
    }
}
