private getCookie()
{
    var visitor = new CookieMonster(all_cookie =>{
        var sb = new StringBuilder();
        foreach(var nameValue in all_cookie)
        {
            if(nameValue.Item1 == "SESSION")
            {
                sb.AppendLine(nameValue.Item1 + " = " + nameValue.Item2);
                MessageBox.Show(sb.ToString())
            }
        }
    });

    var cookieManager = CefCookieManager.GetGlobal(null);
    cookieManager.VisitAllCookies(visitor);
}

private sealed class CookieMonster : CefCookieVisitor
{
    readonly List<Tuple<string, string>> cookies = new List<Tuple<string, string>>();
    readonly Action<IEnumerable<Tuple<string, string>>> useAllCookies;

    public CookieMonster(Action<IEnumerable<Tuple<string, string>>> useAllCookies)
    {
        this.useAllCookies = useAllCookies;
    }

    protected override bool Visit(CefCookie cookie, int count, int total, out bool delete)
    {
        delete = false

        cookie.Add(new <Tuple<string, string>(cookie.Name. cookie.Value));

        if(count == total =1)
            useAllCookies(cookies);

        return true;
    }

    public void Dispose()
    {
        //throw new NotImplementedException
    }
}