public class ClassA{
	private InterfaceB clzB;
	public void doSomething(){
		Object obj=class.forName(Config.BImplementation).newInstance();
		clzB=(InterfaceB)obj;
		clzB.doIt();
	}
}