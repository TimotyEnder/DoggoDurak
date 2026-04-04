public  class SubToolTip
{
    protected  string toolTipString;

    public SubToolTip(string tooltStr)
    {
        this.toolTipString=tooltStr;
    }
    public string GetToolTipString()
    {
        return this.toolTipString;
    }
}