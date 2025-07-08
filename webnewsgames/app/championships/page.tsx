import MainChampionship from "@/components/ChampionshipsComponents/MainChampionship";
import Footer from "@/components/DefaultFooterComponent/Footer";
import GeneralHeader from "@/components/DefaultHeaderComponent/GeneralHeader";

export default function ChampionshipPage() {
  return (
    <div>
      <GeneralHeader PageDescriptor="Campeonatos" />
      <MainChampionship />
      <Footer />
    </div>
  );
}
