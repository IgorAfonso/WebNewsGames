import FeaturedNews from "@/components/HomeCOmponents/FeaturedNews";
import Footer from "@/components/HomeCOmponents/Footer";
import HeaderComponent from "@/components/HomeCOmponents/HomeHeader";
import ListOfNews from "@/components/HomeCOmponents/ListOfNews";

export default function Home() {
  return (
    <div>
      <HeaderComponent />
      <FeaturedNews />
      <ListOfNews />
      <Footer />
    </div>
  );
}
