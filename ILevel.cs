using System.Collections.Generic;
namespace JumpGame
{
    public interface ILevel
    {
        void Init();
        void Tick();

        List<Block> GetBlocks();
    }
}