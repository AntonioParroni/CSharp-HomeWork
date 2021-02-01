//пришло,реализовано, списано, передано

namespace Interface2
{
    public interface IGoodsActions
    {
        void IsArrived(int ArrivedAmount);
        void IsRealized();
        void IsTransfer(int TransferAmount);
        void IsDrop();
    }
}