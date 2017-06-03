//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: table.proto
namespace Table
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CreateReq")]
  public partial class CreateReq : global::ProtoBuf.IExtensible
  {
    public CreateReq() {}
    
    private string _token;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"token", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string token
    {
      get { return _token; }
      set { _token = value; }
    }
    private int _playoffs;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"playoffs", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int playoffs
    {
      get { return _playoffs; }
      set { _playoffs = value; }
    }
    private int _times;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"times", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int times
    {
      get { return _times; }
      set { _times = value; }
    }
    private int _jiangma;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"jiangma", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int jiangma
    {
      get { return _jiangma; }
      set { _jiangma = value; }
    }
    private int _maima;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"maima", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int maima
    {
      get { return _maima; }
      set { _maima = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CreateRsp")]
  public partial class CreateRsp : global::ProtoBuf.IExtensible
  {
    public CreateRsp() {}
    
    private int _tab_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"tab_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int tab_id
    {
      get { return _tab_id; }
      set { _tab_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"JoinReq")]
  public partial class JoinReq : global::ProtoBuf.IExtensible
  {
    public JoinReq() {}
    
    private int _tab_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"tab_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int tab_id
    {
      get { return _tab_id; }
      set { _tab_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Join")]
  public partial class Join : global::ProtoBuf.IExtensible
  {
    public Join() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private Table.Role _role;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"role", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public Table.Role role
    {
      get { return _role; }
      set { _role = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"JoinRsp")]
  public partial class JoinRsp : global::ProtoBuf.IExtensible
  {
    public JoinRsp() {}
    
    private int _err_no;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"err_no", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int err_no
    {
      get { return _err_no; }
      set { _err_no = value; }
    }
    private readonly global::System.Collections.Generic.List<Table.Role> _roles = new global::System.Collections.Generic.List<Table.Role>();
    [global::ProtoBuf.ProtoMember(3, Name=@"roles", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Table.Role> roles
    {
      get { return _roles; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"QuitReq")]
  public partial class QuitReq : global::ProtoBuf.IExtensible
  {
    public QuitReq() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"QuitRsp")]
  public partial class QuitRsp : global::ProtoBuf.IExtensible
  {
    public QuitRsp() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"KickReq")]
  public partial class KickReq : global::ProtoBuf.IExtensible
  {
    public KickReq() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Role")]
  public partial class Role : global::ProtoBuf.IExtensible
  {
    public Role() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private string _name;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private int _pos;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"pos", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int pos
    {
      get { return _pos; }
      set { _pos = value; }
    }
    private bool _ready;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"ready", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool ready
    {
      get { return _ready; }
      set { _ready = value; }
    }
    private bool _online;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"online", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool online
    {
      get { return _online; }
      set { _online = value; }
    }
    private string _url;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"url", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string url
    {
      get { return _url; }
      set { _url = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ReadyReq")]
  public partial class ReadyReq : global::ProtoBuf.IExtensible
  {
    public ReadyReq() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Ready")]
  public partial class Ready : global::ProtoBuf.IExtensible
  {
    public Ready() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Start")]
  public partial class Start : global::ProtoBuf.IExtensible
  {
    public Start() {}
    
    private int _status;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"status", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int status
    {
      get { return _status; }
      set { _status = value; }
    }
    private int _id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private int _round;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"round", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int round
    {
      get { return _round; }
      set { _round = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Cards")]
  public partial class Cards : global::ProtoBuf.IExtensible
  {
    public Cards() {}
    
    private readonly global::System.Collections.Generic.List<int> _cards = new global::System.Collections.Generic.List<int>();
    [global::ProtoBuf.ProtoMember(1, Name=@"cards", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<int> cards
    {
      get { return _cards; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Turn")]
  public partial class Turn : global::ProtoBuf.IExtensible
  {
    public Turn() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Play")]
  public partial class Play : global::ProtoBuf.IExtensible
  {
    public Play() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private int _card;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"card", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int card
    {
      get { return _card; }
      set { _card = value; }
    }
    private readonly global::System.Collections.Generic.List<int> _leftcard = new global::System.Collections.Generic.List<int>();
    [global::ProtoBuf.ProtoMember(3, Name=@"leftcard", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<int> leftcard
    {
      get { return _leftcard; }
    }
  
    private int _err_no;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"err_no", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int err_no
    {
      get { return _err_no; }
      set { _err_no = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Peng")]
  public partial class Peng : global::ProtoBuf.IExtensible
  {
    public Peng() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private int _from;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"from", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int from
    {
      get { return _from; }
      set { _from = value; }
    }
    private int _card;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"card", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int card
    {
      get { return _card; }
      set { _card = value; }
    }
    private int _err_no;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"err_no", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int err_no
    {
      get { return _err_no; }
      set { _err_no = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Angang")]
  public partial class Angang : global::ProtoBuf.IExtensible
  {
    public Angang() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private int _card;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"card", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int card
    {
      get { return _card; }
      set { _card = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Gang")]
  public partial class Gang : global::ProtoBuf.IExtensible
  {
    public Gang() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private int _from;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"from", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int from
    {
      get { return _from; }
      set { _from = value; }
    }
    private int _card;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"card", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int card
    {
      get { return _card; }
      set { _card = value; }
    }
    private int _err_no;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"err_no", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int err_no
    {
      get { return _err_no; }
      set { _err_no = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Hu")]
  public partial class Hu : global::ProtoBuf.IExtensible
  {
    public Hu() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private int _from;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"from", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int from
    {
      get { return _from; }
      set { _from = value; }
    }
    private int _hutype;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"hutype", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int hutype
    {
      get { return _hutype; }
      set { _hutype = value; }
    }
    private int _err_no;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"err_no", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int err_no
    {
      get { return _err_no; }
      set { _err_no = value; }
    }
    private int _card;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"card", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int card
    {
      get { return _card; }
      set { _card = value; }
    }
    private readonly global::System.Collections.Generic.List<int> _cards = new global::System.Collections.Generic.List<int>();
    [global::ProtoBuf.ProtoMember(6, Name=@"cards", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<int> cards
    {
      get { return _cards; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Pass")]
  public partial class Pass : global::ProtoBuf.IExtensible
  {
    public Pass() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private bool _auto;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"auto", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool auto
    {
      get { return _auto; }
      set { _auto = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PassHu")]
  public partial class PassHu : global::ProtoBuf.IExtensible
  {
    public PassHu() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NewCard")]
  public partial class NewCard : global::ProtoBuf.IExtensible
  {
    public NewCard() {}
    
    private int _card;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"card", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int card
    {
      get { return _card; }
      set { _card = value; }
    }
    private int _id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private int _leftcard;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"leftcard", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int leftcard
    {
      get { return _leftcard; }
      set { _leftcard = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SwitchAuto")]
  public partial class SwitchAuto : global::ProtoBuf.IExtensible
  {
    public SwitchAuto() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private bool _isauto;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"isauto", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool isauto
    {
      get { return _isauto; }
      set { _isauto = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"VoiceChat")]
  public partial class VoiceChat : global::ProtoBuf.IExtensible
  {
    public VoiceChat() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private byte[] _data;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"data", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public byte[] data
    {
      get { return _data; }
      set { _data = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"QuickMsg")]
  public partial class QuickMsg : global::ProtoBuf.IExtensible
  {
    public QuickMsg() {}
    
    private int _msgid;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"msgid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int msgid
    {
      get { return _msgid; }
      set { _msgid = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"JiangMa")]
  public partial class JiangMa : global::ProtoBuf.IExtensible
  {
    public JiangMa() {}
    
    private readonly global::System.Collections.Generic.List<int> _cards = new global::System.Collections.Generic.List<int>();
    [global::ProtoBuf.ProtoMember(1, Name=@"cards", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<int> cards
    {
      get { return _cards; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RoundScore")]
  public partial class RoundScore : global::ProtoBuf.IExtensible
  {
    public RoundScore() {}
    
    private readonly global::System.Collections.Generic.List<Table.Score> _scores = new global::System.Collections.Generic.List<Table.Score>();
    [global::ProtoBuf.ProtoMember(1, Name=@"scores", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Table.Score> scores
    {
      get { return _scores; }
    }
  
    private readonly global::System.Collections.Generic.List<Table.EndCards> _end_cards = new global::System.Collections.Generic.List<Table.EndCards>();
    [global::ProtoBuf.ProtoMember(2, Name=@"end_cards", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Table.EndCards> end_cards
    {
      get { return _end_cards; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"EndCards")]
  public partial class EndCards : global::ProtoBuf.IExtensible
  {
    public EndCards() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private readonly global::System.Collections.Generic.List<int> _cards = new global::System.Collections.Generic.List<int>();
    [global::ProtoBuf.ProtoMember(2, Name=@"cards", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<int> cards
    {
      get { return _cards; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Score")]
  public partial class Score : global::ProtoBuf.IExtensible
  {
    public Score() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private int _hu;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"hu", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int hu
    {
      get { return _hu; }
      set { _hu = value; }
    }
    private int _hu_type;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"hu_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int hu_type
    {
      get { return _hu_type; }
      set { _hu_type = value; }
    }
    private int _score;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"score", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int score
    {
      get { return _score; }
      set { _score = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}