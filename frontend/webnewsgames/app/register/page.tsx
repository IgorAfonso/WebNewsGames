import Footer from "@/components/DefaultFooterComponent/Footer";
import LoginHeaderComponent from "@/components/LoginPageCOmponents/LoginHeader";
import RegisterBody from "@/components/RegisterPageComponents/RegisterBody";

export default function RegisterPage() {
  return (
    <div className="bg-lightGray min-h-screen font-sans">
      <LoginHeaderComponent />
      <RegisterBody />
      <Footer />
    </div>
  );
}
