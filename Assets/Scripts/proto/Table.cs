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
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}