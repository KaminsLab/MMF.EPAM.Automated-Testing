# 10 test cases

## Case 1
<https://pass.rw.by/en/?c=true>
- Scroll to *Schedule and search for tickets*
- Select type of ticket (One-way/Round-trip/Composite route)
- Input valid place into From and To sections, select reach (and departure) date
	(ex: Minsk, Hrodna, 14 Oct. 2021)
- Click *FIND*
---
Expected : List of available trips.

## Case 2
<https://pass.rw.by/en/?c=true>
- Scroll to *Schedule and search for tickets*
- Select type of ticket (One-way/Round-trip/Composite route)
- Input valid place into From and To sections, select reach (and departure) date
	(ex: Minsk, Kyiv, 15 Oct. 2021)
- Click *FIND*
---
Expected : Message - *No direct communication between station*

## Case 3
<https://pass.rw.by/en/?c=true>
- Scroll to *Schedule and search for tickets*
- Select type of ticket (One-way/Round-trip/Composite route)
- Input invalid place into From and To sections, select reach (and departure) date
	(ex: abbb, Kyiv, 15 Oct. 2021)
- Click *FIND*
---
Expected : Message - *Please clarify arrival / departure stations*

## Case 4
<https://pass.rw.by/en/?c=true>
- Scroll to *Schedule and search for tickets*
- Select type of ticket (One-way/Round-trip/Composite route)
- Input date without departures into From and To sections, select reach (and departure) date
	(ex: Minsk, Polack, today)
- Click *FIND*
- Select morning departure/arrival
---
Expected : List of departed trains

## Case 5
<https://pass.rw.by/en/?c=true>
- Scroll to *Popular routes*
- Click *BUY TICKET* on certain offer
---
Expected : List of available trips for direction

## Case 6
https://pass.rw.by/en/?c=true
- Scroll to *Passenger Background*
- Click *Travel documents*
---
Expected : Redirect to <https://pass.rw.by/en/help/tickets/>

## Case 7
<https://pass.rw.by/en/?c=true>
- Scroll to *Passenger Background*
- Click on *Watch the video*
---
Expected : video load

## Case 8
<https://pass.rw.by/en/?c=true>
- Click Online shcedule
---
Expected : List of the nearestd trains departures

## Case 9
<https://pass.rw.by/en/help/children_transportation/>
- Click *ALL CONTACT INFORMATION*
---
Expected : return <https://pass.rw.by/en/railway_stations/> with list of stations

## Case 10
<https://pass.rw.by/en/help/children_transportation/>
- Click *ALL CONTACT INFORMATION*
- Click *Viciebsk Railway Station*
---
Expected : return <https://pass.rw.by/en/railway_stations/vitebsk/> - info about stations