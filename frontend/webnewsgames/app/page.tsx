import FeaturedNews from "@/components/HomeComponents/FeaturedNews";
import Footer from "@/components/DefaultFooterComponent/Footer";
import ListOfNews from "@/components/HomeComponents/ListOfNews";
import GeneralHeader from "@/components/DefaultHeaderComponent/GeneralHeader";
import CarrosselCampeonatos from "@/components/Carousel Component/Carousel";

export default function Home() {
  return (
    <div>
      <GeneralHeader PageDescriptor="Bem Vindo!" />;
      <CarrosselCampeonatos />
      <FeaturedNews />
      <ListOfNews />
      <Footer />
    </div>
  );
}
