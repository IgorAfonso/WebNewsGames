import FeaturedNews from "@/components/HomeComponents/FeaturedNews";
import Footer from "@/components/DefaultFooterComponent/Footer";
import ListOfNews from "@/components/HomeComponents/ListOfNews";
import GeneralHeader from "@/components/DefaultHeaderComponent/GeneralHeader";
import CarrosselCampeonatos from "@/components/Carousel Component/Carousel";
import GeneralNewsSection from "@/components/HomeComponents/GeneralNewsSection";
import HomeSearchAction from "@/components/HomeComponents/HomeSearchAction";

export default function HomePageContent() {
  return (
    <div>
      <GeneralHeader PageDescriptor="Web News" />
      <HomeSearchAction />
      <CarrosselCampeonatos />
      <FeaturedNews />
      <ListOfNews />
      <GeneralNewsSection />
      <Footer />
    </div>
  );
}
