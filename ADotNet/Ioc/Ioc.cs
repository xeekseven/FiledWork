class MovieLister
{

	public MovieLister(MovieFinder finder)
	{
		this.finder=finder;
	}


}
class ColonMovieFinder
{
	public ColonMovieFinder(string filename)
	{
		this.filename=filename;
	}
}
class AnotherClass
{
	private MutablePicoContainer configureContainer()
	{
		MutablePicoContainer pico=new DefaultPicoContainer();
		Parameter[] finderParams={ new ConstantParameter("movie1.txt")};
		pico.registerComponentTmplementation(MovieFinder.class,ColonMovieFinder.class,finderParams);
		pico.registerComponentTmplementation(MovieLister.class);
		return pico;
	}
}
