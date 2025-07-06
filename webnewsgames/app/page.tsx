import FeaturedNews from "@/components/HomeComponents/FeaturedNews";
import Footer from "@/components/DefaultFooterComponent/Footer";
import ListOfNews from "@/components/HomeComponents/ListOfNews";
import GeneralHeader from "@/components/DefaultHeaderComponent/GeneralHeader";

export default function Home() {
  return (
    <div>
      <GeneralHeader PageDescriptor="Pagina Inicial" />;
      <FeaturedNews />
      <ListOfNews />
      <Footer />
    </div>
  );
}
