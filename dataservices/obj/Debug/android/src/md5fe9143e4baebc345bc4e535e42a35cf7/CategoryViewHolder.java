package md5fe9143e4baebc345bc4e535e42a35cf7;


public class CategoryViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("dataservices.Holders.CategoryViewHolder, dataservices, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CategoryViewHolder.class, __md_methods);
	}


	public CategoryViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == CategoryViewHolder.class)
			mono.android.TypeManager.Activate ("dataservices.Holders.CategoryViewHolder, dataservices, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
