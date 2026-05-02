import MainChampionship from "@/components/ChampionshipsComponents/MainChampionship";
import Footer from "@/components/DefaultFooterComponent/Footer";
import GeneralHeader from "@/components/DefaultHeaderComponent/GeneralHeader";
import MostRecentyChampionships from "@/components/MostRecentChampionshipsComponent/MstRecentyChamp";

export default function ChampionshipPage() {
  return (
    <div>
      <GeneralHeader PageDescriptor="Web News" />
      <MainChampionship />
      <MostRecentyChampionships />
      <Footer />
    </div>
  );
}
