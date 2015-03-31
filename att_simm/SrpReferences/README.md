# Document de référence #

## Command line ##

Ouvrir Chrome sans sécurité web: 
    
    cd C:\Program Files (x86)\Google\Chrome
    chrome.exe --user-data-dir="C:/Chrome dev session" --disable-web-security

## Projets de Simon Robichaud-Paré ##

## DropDownListFor qui change en Ajax ##
    $('#IDDROPDOWNPRIMAIRE').change(function () {
            var selectedValue = $(this).val();
            $.post('@Url.Action("ACTION", "CONTROLLER")', { selection: selectedValue }, function (data) {
                console.log(data);
                var $el = $("#DROPDOWNLISTACHANGER");
                $el.empty(); // On enlève les vieilles options
                $.each(data, function (Value, Text) {
                    $el.append($("<option></option>")
                       .attr("value", Value).text(Text.Text));
                });
            });
        });

Le controller doit retourner du JSON d'une list de SelectListItem. Exemple:

    public ActionResult ChangeTournament(string selection)
        {
            int tournamentID = Convert.ToInt32(selection);
            Tournament t = db.Tournament.GetTournament(tournamentID);
            List<SelectListItem> teamlist = new List<SelectListItem>();
            foreach (var team in db.League.GetLeaguesFromDistrict((int)t.DistrictID))
            {
                teamlist.Add(new SelectListItem { Selected = false, Text = team.City, Value = team.ID.ToString() });
            }
            return Json(teamlist);
        }

**Pour référence voir le projet PetiteLigueQuébec**

## Passer une liste d'objets en JSON AJAX ##

    $("#savescores").click(function () {
            event.preventDefault();
            $("#loading-wrap").css("display", "block");
            var MatchJSON = [];
            $(".table-row").each(function () {
                var matchi = $(this).attr("data-id");
                MatchJSON.push({
                    "MatchID": matchi,
                    "ResultTeam1": $("#scoreteam1_" + matchi).val(),
                    "ResultTeam2": $("#scoreteam2_" + matchi).val()
                });
            });
            console.log(JSON.stringify(MatchJSON));
            $.ajax({
                type: "POST",
                url: '@Url.Action("SetScores", "GestionMatchs")',
                data: JSON.stringify(MatchJSON),
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    $("#loading-wrap").css("display", "none");
                }
            });
        });
Côté serveur on va vouloir catcher l'objet avec une liste d'objet du même type:

    [HttpPost]
    public ActionResult SetScores(IList<MatchResult> MatchJSON)
    {
          foreach (var match in MatchJSON)
          {
               Match temp = db.Match.GetMatch(Convert.ToInt32(match.MatchID));
               temp.ScoreTeam1 = Convert.ToInt32(match.ResultTeam1);
               temp.ScoreTeam2 = Convert.ToInt32(match.ResultTeam2);
               db.Match.InsertEditMatch(temp);
          }
          return Json("OK");
    }
    public class MatchResult
    {
        public string MatchID { get; set; }
        public string ResultTeam1 { get; set; }
        public string ResultTeam2 { get; set; }
    }

**Pour référence voir le projet PetiteLigueQuébec**

## Valider les integer en JS ##

        $(".score").change(function () {
            if (isNormalInteger($(this).val())) {

            }
            else {
                $(this).val(0);
            }
        });
        function isNormalInteger(str) {
            var n = ~~Number(str);
            return String(n) === str && n >= 0;
        }
**Pour référence voir le projet PetiteLigueQuébec

**Pour r�f�rence voir le projet de GD

##Extensions methods ##
Ex:

public static class ExtensionMethods
{
        public static string UppercaseFirstLetter(this string value)
        {
            if (value.Length > 0)
            {
                char[] array = value.ToCharArray();
                array[0] = char.ToUpper(array[0]);
                return new string(array);
            }
            return value;
        }
}
� integrer �ventuellement dans SRPCLASS
