using System.Collections;
using System.Collections.Generic;
using RPG.Metagame.Player;
using RPG.Shared.Dialog;

public class CreationQuestionnareDialog : Dialog<CreationQuestionnareArgs, CreationQuestionnareResult>
{
    protected override void OnOpen(CreationQuestionnareArgs args)
    {
        
    }

    protected override void OnClose(CreationQuestionnareResult args)
    {
        
    }
}
public class CreationQuestionnareResult : DialogResult
{
    public readonly PlayerAttributes playerAttributes;

    public CreationQuestionnareResult(PlayerAttributes attributes)
    {
        playerAttributes = attributes;
    }
}
public class CreationQuestionnareArgs : DialogArgs
{
    public string Text1;
    public string Text2;
    public string Text3;
}
