<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRegister.aspx.cs" Inherits="user_UserRegister" %>

<%@ Register src="../Tool/foot.ascx" tagname="foot" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/userlogin.css" />
    <title>陇原商城会员注册</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="main">
        <div class="top">
            <div class="topleft">
                &nbsp;<img src="../images/logoo.jpg" alt="陇原商城欢迎您" />
            </div>
            <div class="topright">
                <img src="../images/login06.gif" alt="陇原商城" />
                <ul>
                    <li><a href="UserLogin.aspx">登录</a>&nbsp;&nbsp;<a href="../proscenium/Index.aspx">返回首页</a>&nbsp; <a href="#">新手帮助</a>&nbsp; </li>
                </ul>
            </div>
        </div>
        <div class="content">
            <div class="contentloginv">
                <div class="contentonev">
                    <img src="../images/login11.gif" alt="陇原商城"/>
                </div>
                <div class="contenttwov">
                    <div class="conterloginone">
                        <ul>
			                <li><strong><span class="yanse">1填写信息 ></span> 2提交 > 3&gt;填写详细信息&gt;4注册成功 </strong></li>
			            </ul>
                    </div>
                    <div class="logincontent">
                        <div class="logincontentv">
                            <div class="logincontentphoto"><img src="../images/login18.gif" alt="会员注册" />
                                <ul>
                                    <li>以下信息不能为空</li>
                                </ul>
                            </div>
                        </div>
                        <div class="loginzcneir">
                            <div class="loginzcneirone">
                                <div class="loginzcneironeleft">
                                    <div class="loginzcneironeleft1">
                                        <ul>
                                            <li>会&nbsp; 员&nbsp; 名：<asp:TextBox ID="txtUserName" runat="server" MaxLength="20" Width="120px" 
 ></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="txtUserName_TextBoxWatermarkExtender" 
                                                    runat="server" Enabled="True" TargetControlID="txtUserName" 
                                                    WatermarkCssClass="watermark" WatermarkText="请输入正确的会员名">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" 
                                                    ErrorMessage="会员名不能为空" ControlToValidate="txtUserName" Display="Dynamic">*</asp:RequiredFieldValidator>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="loginzcneironeright">
                                    <ul>
                                        <li>温馨提示：5-20个字符(包括小写字母、数字、下划线、中文)，一个汉字为两个字符，推荐使用中文会员名。一旦注册成功会员名不能修改。</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="loginzcneirone">
                                <div class="loginzcneironeleft">
                                    <div class="loginzcneironeleft1">
                                        <ul>
                                            <li>密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 码：<asp:TextBox ID="txtPassword" 
                                                    runat="server" Width="120px" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                                                    ErrorMessage="密码不能为空" ControlToValidate="txtPassword" Display="Dynamic">*</asp:RequiredFieldValidator>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="loginzcneironeright">
                                    <ul>
                                        <li>温馨提示：6-16个字符请使用字母加数字或符号的组合密码，最好不要单独使用字母，数字或者符号</li>
                                    </ul>
                                </div>
                            </div>
                            <div class="loginzcneirone">
                                <div class="loginzcneironeleft">
                                    <div class="loginzcneironeleft1">
                                        <ul>
                                            <li>确认密码：<asp:TextBox ID="txtOKPassword" runat="server" TextMode="Password" 
                                                    Width="120px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvOKPassworf" runat="server" 
                                                    ErrorMessage="确认密码不能为空" ControlToValidate="txtPassword" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                    ControlToCompare="txtOKPassword" ControlToValidate="txtPassword" 
                                                    Display="Dynamic" EnableTheming="True" ErrorMessage="两次密码输入不一致，请检查！" 
                                                    Operator="GreaterThanEqual">*</asp:CompareValidator>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                 <div class="loginzcneironeright">
                                    <ul>
                                        <li>温馨提示：请再次输入密码，确保和上一次输入一致</li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                  <div class="loginzc2">
                    <div class="logincontentv">
                        <div class="logincontentphoto">
                            <img src="../images/login30.gif" alt="邮箱注册"/>
                            <ul>
                                <li>请填写常用的电子邮件地址</li>
                            </ul>
                        </div>
                    </div>
                    <div class="loginzcneirone">
                        <div class="loginzcneironeleft">
                            <div class="loginzcneironeleft1">
                                <ul>
                                    <li>电子邮件：
                                    <asp:TextBox ID="txtEmail" runat="server" Width="120px"></asp:TextBox>
                                        <cc1:TextBoxWatermarkExtender ID="txtEmail_TextBoxWatermarkExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtEmail" 
                                            WatermarkCssClass="watermark" WatermarkText="请输入正确的电子邮件">
                                        </cc1:TextBoxWatermarkExtender>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                                ErrorMessage="电子邮件不能为空" ControlToValidate="txtEmail" Display="Dynamic">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                                            ErrorMessage="电子邮件格式不正确，请检查" ControlToValidate="txtEmail" Display="Dynamic" 
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="loginzcneironeright">
                          <ul>
                             <li>温馨提示：请输入你经常使用的正确的邮箱地址，在某些活动时可以使用到邮箱</li>
                          </ul>
                       </div>
                    </div>
                    <div class="loginzcneirone">
                        <div class="loginzcneironeleft">
                            <div class="loginzcneironeleft1">
                                <ul>
                                    <li>验 证 码：<asp:TextBox ID="txtCode" Width="100px" runat="server" Height="19px"></asp:TextBox>
                                        <cc1:TextBoxWatermarkExtender ID="txtCode_TextBoxWatermarkExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtCode" 
                                            WatermarkCssClass="watermark" WatermarkText="请输入正确的验证码">
                                        </cc1:TextBoxWatermarkExtender>
                                        <img src="../Tool/CheckInage.aspx" onclick="this.src=this.src+'?'" id="imgcode" title="点击刷新验证码" style="vertical-align:middle; cursor:pointer; margin:0px; padding:0px" alt="陇原商城"/>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtCode" Display="Dynamic" ErrorMessage="验证码不能为空">*</asp:RequiredFieldValidator></li>
                                </ul>
                            </div>
                        </div>
                        <div class="loginzcneironeright">
					       <ul>
					          <li>温馨提示：为了网站的安全，请您输入正确的验证码  
					       </ul>
					   </div>
                    </div>
                  </div>
                  <div class="loginfoot">
                    <div class="loginbottom">
                                <asp:CheckBox ID="cbAccept" runat="server" 
    Text="阅读陇原网上超市服务协议" Checked="True" />
                        &nbsp;<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtDeal" runat="server" ReadOnly="True" TextMode="MultiLine" 
                            MaxLength="100000" Height="60px" Width="890px">     本协议由您与浙江淘宝网络有限公司共同缔结，本协议具有合同效力。
本协议中协议双方合称协议方，浙江淘宝网络有限公司在协议中亦称为“淘宝”。本协议中“淘宝平台”指由浙江淘宝网络有限公司运营的网络交易平台，包括淘宝网，域名为 taobao.com；淘宝商城，域名为tmall.com；一淘网，域名为etao.com。
一、	协议内容及签署
1.本协议内容包括协议正文及所有淘宝已经发布的或将来可能发布的各类规则。所有规则为本协议不可分割的组成部分，与协议正文具有同等法律效力。除另行明确声明外，任何淘宝及其关联公司提供的服务（以下称为淘宝平台服务）均受本协议约束。
2.您应当在使用淘宝平台服务之前认真阅读全部协议内容，对于协议中以加粗字体显示的内容，您应重点阅读。如您对协议有任何疑问的，应向淘宝咨询。但无论您事实上是否在使用淘宝平台服务之前认真阅读了本协议内容，只要您使用淘宝平台服务，则本协议即对您产生约束，届时您不应以未阅读本协议的内容或者未获得淘宝对您问询的解答等理由，主张本协议无效，或要求撤销本协议。
3.您承诺接受并遵守本协议的约定。如果您不同意本协议的约定，您应立即停止注册程序或停止使用淘宝平台服务。
4.淘宝有权根据需要不时地制订、修改本协议及/或各类规则，并以网站公示的方式进行公告，不再单独通知您。变更后的协议和规则一经在网站公布后，立即自动生效。如您不同意相关变更，应当立即停止使用淘宝平台服务。您继续使用淘宝平台服务的，即表示您接受经修订的协议和规则。

二、	注册
1.注册者资格
您确认，在您完成注册程序或以其他淘宝允许的方式实际使用淘宝平台服务时，您应当是具备完全民事权利能力和完全民事行为能力的自然人、法人或其他组织。若您不具备前述主体资格，则您及您的监护人应承担因此而导致的一切后果，且淘宝有权注销（永久冻结）您的淘宝账户，并向您及您的监护人索偿。
2.账户
在您签署本协议，完成会员注册程序或以其他淘宝允许的方式实际使用淘宝平台服务时，淘宝会向您提供唯一编号的淘宝账户（以下亦称账户）。
您可以对账户设置会员名和密码，通过该会员名密码或与该会员名密码关联的其它用户名密码登陆淘宝平台。您设置的会员名不得侵犯或涉嫌侵犯他人合法权益。如您连续一年未使用您的会员名和密码登录淘宝平台，淘宝有权终止向您提供淘宝平台服务，注销您的账户。账户注销后，相应的会员名将开放给任意用户注册登记使用。
您应对您的账户（会员名）和密码的安全，以及对通过您的账户（会员名）和密码实施的行为负责。除非有法律规定或司法裁定，且征得淘宝的同意，否则，账户（会员名）和密码不得以任何方式转让、赠与或继承（与账户相关的财产权益除外）。如果发现任何人不当使用您的账户或有任何其他可能危及您的账户安全的情形时，您应当立即以有效方式通知淘宝，要求淘宝暂停相关服务。您理解淘宝对您的请求采取行动需要合理时间，淘宝对在采取行动前已经产生的后果（包括但不限于您的任何损失）不承担任何责任。
为方便您使用淘宝平台服务及淘宝关联公司或其他组织的服务（以下称其他服务），您同意并授权淘宝将您在注册、使用淘宝平台服务过程中提供、形成的信息传递给向您提供其他服务的淘宝关联公司或其他组织，或从提供其他服务的淘宝关联公司或其他组织获取您在注册、使用其他服务期间提供、形成的信息。

3.会员
在您按照注册页面提示填写信息、阅读并同意本协议并完成全部注册程序后或以其他淘宝允许的方式实际使用淘宝平台服务时，您即成为淘宝平台会员（亦称会员）。
在注册时，您应当按照法律法规要求，或注册页面的提示准确提供，并及时更新您的资料，以使之真实、及时，完整和准确。如有合理理由怀疑您提供的资料错误、不实、过时或不完整的，淘宝有权向您发出询问及/或要求改正的通知，并有权直接做出删除相应资料的处理，直至中止、终止对您提供部分或全部淘宝平台服务。淘宝对此不承担任何责任，您将承担因此产生的任何直接或间接支出。
您应当准确填写并及时更新您提供的电子邮件地址、联系电话、联系地址、邮政编码等联系方式，以便淘宝或其他会员与您进行有效联系，因通过这些联系方式无法与您取得联系，导致您在使用淘宝平台服务过程中产生任何损失或增加费用的，应由您完全独自承担。
您在使用淘宝平台服务过程中，所产生的应纳税赋，以及一切硬件、软件、服务及其它方面的费用，均由您独自承担。

三、 淘宝平台服务
1.通过淘宝及其关联公司提供的淘宝平台服务和其它服务，会员可在淘宝平台上发布交易信息、查询商品和服务信息、达成交易意向并进行交易、对其他会员进行评价、参加淘宝组织的活动以及使用其它信息服务及技术服务。
2.您在淘宝平台上交易过程中与其他会员发生交易纠纷时，一旦您或其它会员任一方或双方共同提交淘宝要求调处，则淘宝有权根据单方判断做出调处决定，您了解并同意接受淘宝的判断和调处决定。该决定将对您具有法律约束力。
3.您了解并同意，淘宝有权应政府部门（包括司法及行政部门）的要求，向其提供您在淘宝平台填写的注册信息和交易纪录等必要信息。如您涉嫌侵犯他人知识产权，则淘宝亦有权在初步判断涉嫌侵权行为存在的情况下，向权利人提供您必要的身份信息。

四、	淘宝平台服务使用规范
1.在淘宝平台上使用淘宝服务过程中，您承诺遵守以下约定：
a)	在使用淘宝平台服务过程中实施的所有行为均遵守国家法律、法规等规范性文件及淘宝平台各项规则的规定和要求，不违背社会公共利益或公共道德，不损害他人的合法权益，不违反本协议及相关规则。您如果违反前述承诺，产生任何法律后果的，您应以自己的名义独立承担所有的法律责任，并确保淘宝免于因此产生任何损失。
b)	在与其他会员交易过程中，遵守诚实信用原则，不采取不正当竞争行为，不扰乱网上交易的正常秩序，不从事与网上交易无关的行为。
c)	不发布国家禁止销售的或限制销售的商品或服务信息（除非取得合法且足够的许可），不发布涉嫌侵犯他人知识产权或其它合法权益的商品或服务信息，不发布违背社会公共利益或公共道德或淘宝认为不适合在淘宝平台上销售的商品或服务信息，不发布其它涉嫌违法或违反本协议及各类规则的信息。
d)	不以虚构或歪曲事实的方式不当评价其他会员，不采取不正当方式制造或提高自身的信用度，不采取不正当方式制造或提高（降低）其他会员的信用度；
e)	不对淘宝平台上的任何数据作商业性利用，包括但不限于在未经淘宝事先书面同意的情况下，以复制、传播等任何方式使用淘宝平台站上展示的资料。
f)	不使用任何装置、软件或例行程序干预或试图干预淘宝平台的正常运作或正在淘宝平台上进行的任何交易、活动。您不得采取任何将导致不合理的庞大数据负载加诸淘宝平台网络设备的行动。
2.您了解并同意：
a)	淘宝有权对您是否违反上述承诺做出单方认定，并根据单方认定结果适用规则予以处理或终止向您提供服务，且无须征得您的同意或提前通知予您。
b)	经国家行政或司法机关的生效法律文书确认您存在违法或侵权行为，或者淘宝根据自身的判断，认为您的行为涉嫌违反本协议和/或规则的条款或涉嫌违反法律法规的规定的，则淘宝有权在淘宝平台上公示您的该等涉嫌违法或违约行为及淘宝已对您采取的措施。
c)	对于您在淘宝平台上发布的涉嫌违法或涉嫌侵犯他人合法权利或违反本协议和/或规则的信息，淘宝有权不经通知您即予以删除，且按照规则的规定进行处罚。
d)	对于您在淘宝平台上实施的行为，包括您未在淘宝平台上实施但已经对淘宝平台及其用户产生影响的行为，淘宝有权单方认定您行为的性质及是否构成对本协议和/或规则的违反，并据此作出相应处罚。您应自行保存与您行为有关的全部证据，并应对无法提供充要证据而承担的不利后果。
e)	对于您涉嫌违反承诺的行为对任意第三方造成损害的，您均应当以自己的名义独立承担所有的法律责任，并应确保淘宝免于因此产生损失或增加费用。
f)	如您涉嫌违反有关法律或者本协议之规定，使淘宝遭受任何损失，或受到任何第三方的索赔，或受到任何行政管理部门的处罚，您应当赔偿淘宝因此造成的损失及（或）发生的费用，包括合理的律师费用。

五、	特别授权
您完全理解并不可撤销地授予淘宝及其关联公司下列权利：
1.一旦您向淘宝及（或）其关联公司，包括但不限于阿里巴巴、支付宝、阿里金融、阿里云，中国雅虎等作出任何形式的承诺，且相关公司已确认您违反了该承诺，则淘宝有权立即按您的承诺或协议约定的方式对您的账户采取限制措施，包括中止或终止向您提供服务，并公示相关公司确认的您的违约情况。您了解并同意，淘宝无须就相关确认与您核对事实，或另行征得您的同意，且淘宝无须就此限制措施或公示行为向您承担任何的责任。
2.一旦您违反本协议，或与淘宝签订的其他协议的约定，淘宝有权以任何方式通知淘宝关联公司，要求其对您的权益采取限制措施，包括但不限于要求支付宝公司将您账户内的款项支付给淘宝指定的对象，要求关联公司中止、终止对您提供部分或全部服务，且在其经营或实际控制的任何网站公示您的违约情况。
3.对于您提供的资料及数据信息，您授予淘宝及其关联公司独家的、全球通用的、永久的、免费的许可使用权利 (并有权在多个层面对该权利进行再授权)。此外，淘宝及其关联公司有权(全部或部份地) 使用、复制、修订、改写、发布、翻译、分发、执行和展示您的全部资料数据（包括但不限于注册资料、交易行为数据及全部展示于淘宝平台的各类信息）或制作其派生作品，并以现在已知或日后开发的任何形式、媒体或技术，将上述信息纳入其它作品内。

六、责任范围和责任限制
1.淘宝负责按"现状"和"可得到"的状态向您提供淘宝平台服务。但淘宝对淘宝平台服务不作任何明示或暗示的保证，包括但不限于淘宝平台服务的适用性、没有错误或疏漏、持续性、准确性、可靠性、适用于某一特定用途。同时，淘宝也不对淘宝平台服务所涉及的技术及信息的有效性、准确性、正确性、可靠性、质量、稳定、完整和及时性作出任何承诺和保证。
2.您了解淘宝平台上的信息系用户自行发布，且可能存在风险和瑕疵。淘宝平台仅作为交易地点。淘宝平台仅作为您获取物品或服务信息、物色交易对象、就物品和/或服务的交易进行协商及开展交易的场所，但淘宝无法控制交易所涉及的物品的质量、安全或合法性，商贸信息的真实性或准确性，以及交易各方履行其在贸易协议中各项义务的能力。您应自行谨慎判断确定相关物品及/或信息的真实性、合法性和有效性，并自行承担因此产生的责任与损失。
3.除非法律法规明确要求，或出现以下情况，否则，淘宝没有义务对所有用户的注册数据、商品（服务）信息、交易行为以及与交易有关的其它事项进行事先审查：
a)	淘宝有合理的理由认为特定会员及具体交易事项可能存在重大违法或违约情形。
b)	淘宝有合理的理由认为用户在淘宝平台的行为涉嫌违法或不当。
4.淘宝及其关联公司有权受理您与其他会员因交易产生的争议，并有权单方判断与该争议相关的事实及应适用的规则，进而作出处理决定。该处理决定对您有约束力。如您未在限期内执行处理决定的，则淘宝及其关联公司有权利（但无义务）直接使用您支付宝账户内的款项，或您向淘宝及其关联公司交纳的保证金代为支付。您应及时补足保证金并弥补淘宝及其关联公司的损失，否则淘宝及其关联公司有权直接抵减您在其它合同项下的权益，并有权继续追偿。
您理解并同意，淘宝及其关联公司并非司法机构，仅能以普通人的身份对证据进行鉴别，淘宝及其关联公司对争议的调处完全是基于您的委托，淘宝及其关联公司无法保证争议处理结果符合您的期望，也不对争议调处结论承担任何责任。如您因此遭受损失，您同意自行向受益人索偿。
5.您了解并同意，淘宝不对因下述任一情况而导致您的任何损害赔偿承担责任，包括但不限于利润、商誉、使用、数据等方面的损失或其它无形损失的损害赔偿 (无论淘宝是否已被告知该等损害赔偿的可能性) ：
a)	使用或未能使用淘宝平台服务。
b)	第三方未经批准的使用您的账户或更改您的数据。
c)	通过淘宝平台服务购买或获取任何商品、样品、数据、信息或进行交易等行为或替代行为产生的费用及损失。
d)	您对淘宝平台服务的误解。
e)	任何非因淘宝的原因而引起的与淘宝平台服务有关的其它损失。
6.不论在何种情况下，淘宝均不对由于信息网络正常的设备维护，信息网络连接故障，电脑、通讯或其他系统的故障，电力故障，罢工，劳动争议，暴乱，起义，骚乱，生产力或生产资料不足，火灾，洪水，风暴，爆炸，战争，政府行为，司法行政机关的命令或第三方的不作为而造成的不能服务或延迟服务承担责任。

七、	协议终止
1.您同意，淘宝有权自行全权决定以任何理由不经事先通知的中止、终止向您提供部分或全部淘宝平台服务，暂时冻结或永久冻结（注销）您的账户，且无须为此向您或任何第三方承担任何责任。
2.出现以下情况时，淘宝有权直接以注销账户的方式终止本协议:
a)	淘宝终止向您提供服务后，您涉嫌再一次直接或间接或以他人名义注册为淘宝用户的；
b)	您提供的电子邮箱不存在或无法接收电子邮件，且没有其他方式可以与您进行联系，或淘宝以其它联系方式通知您更改电子邮件信息，而您在淘宝通知后三个工作日内仍未更改为有效的电子邮箱的。
c)	您注册信息中的主要内容不真实或不准确或不及时或不完整。
d)	本协议（含规则）变更时，您明示并通知淘宝不愿接受新的服务协议的；
e)	其它淘宝认为应当终止服务的情况。
3.您有权向淘宝要求注销您的账户，经淘宝审核同意的，淘宝注销（永久冻结）您的账户，届时，您与淘宝基于本协议的合同关系即终止。您的账户被注销（永久冻结）后，淘宝没有义务为您保留或向您披露您账户中的任何信息，也没有义务向您或第三方转发任何您未曾阅读或发送过的信息。
4.您同意，您与淘宝的合同关系终止后，淘宝仍享有下列权利
a)	继续保存您的注册信息及您使用淘宝平台服务期间的所有交易信息。
b)	您在使用淘宝平台服务期间存在违法行为或违反本协议和/或规则的行为的，淘宝仍可依据本协议向您主张权利。
5.淘宝中止或终止向您提供淘宝平台服务后，对于您在服务中止或终止之前的交易行为依下列原则处理，您应独力处理并完全承担进行以下处理所产生的任何争议、损失或增加的任何费用，并应确保淘宝免于因此产生任何损失或承担任何费用：
a)	您在服务中止或终止之前已经上传至淘宝平台的物品尚未交易的，淘宝有权在中止或终止服务的同时删除此项物品的相关信息；
b)	您在服务中止或终止之前已经与其他会员达成买卖合同，但合同尚未实际履行的，淘宝有权删除该买卖合同及其交易物品的相关信息；
c)	您在服务中止或终止之前已经与其他会员达成买卖合同且已部分履行的，淘宝可以不删除该项交易，但淘宝有权在中止或终止服务的同时将相关情形通知您的交易对方。

八、隐私权政策
淘宝将在淘宝平台公布并不时修订隐私权政策，隐私权政策构成本协议的有效组成部分。

九、法律适用、管辖与其他
1.本协议之效力、解释、变更、执行与争议解决均适用中华人民共和国法律，如无相关法律规定的，则应参照通用国际商业惯例和（或）行业惯例。
2.因本协议产生之争议，应依照中华人民共和国法律予以处理，并以浙江省杭州市西湖区人民法院为第一审管辖法院。
</asp:TextBox>
                    </div>
                  </div>
                  <div class="loginfoot">
                    <div class="loginbottom">
                        <br />
                        <br />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Height="16px" 
                            ShowMessageBox="True" ShowSummary="False" Width="900px" />
                        <br />
                        <br />
                        <asp:Button ID="btnreg" runat="server" Text="会员注册" onclick="btnreg_Click" />
                    </div>
                  </div>
                </div>
            </div>
            <div class="foot">
                <div class="footindex">
                     <ul>
                          <li>免费注册 | 搜索商品 | 如何购物 |买家信息：购物车 | 我的订单 | 我的积分 |商城服务：7天无理由退款 | 积分使用 | 入驻商城 |</li>
                          <li>客服电话：13756862553   注：客服热线吧受理商品咨询! 如需购买咨询 请直接联系该商品的商家</li>
                          <li>关于陇原网上商城 | 帮助中心 | 联系我们 | 版权说明 | 各类商品 | 积分查询 | 返回首页|</li>
                          <li>20011－2022@版权所有 中国·陇原商城有限责任公司  QQ:934532778 </li>
                     </ul>
               </div>
           </div>
        </div>
    </div>
</form>
</body>
</html>
