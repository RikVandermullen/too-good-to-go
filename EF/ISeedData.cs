namespace TGTG_EF
{

    public interface ISeedData
    {
        Task EnsurePopulated(bool dropExisting = false);
    }
}