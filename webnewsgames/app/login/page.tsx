import Footer from "@/components/HomeCOmponents/Footer";
import LoginBody from "@/components/LoginPageCOmponents/LoginBody";
import LoginHeaderComponent from "@/components/LoginPageCOmponents/LoginHeader";

export default function LoginPage() {
  return (
    <div className="bg-lightGray min-h-screen font-sans">
      <LoginHeaderComponent />
      <LoginBody />
      <Footer />
    </div>
  );
}
