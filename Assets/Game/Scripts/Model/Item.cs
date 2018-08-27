//所有交互对象需实现的接口
public interface Item{
    //当手柄交互时调用的方法，参数为交互对象在场景中的名字
    void Dispose(string name);
}