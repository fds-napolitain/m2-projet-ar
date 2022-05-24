# Virtual piano with assistant
An augmented piano with LeapMotion XR Controller. It assists the player at playing notes in correct rythm, identify chords etc.

### tl;dr : Demo (french)

- Movements :
https://www.youtube.com/watch?v=EnPYldUcp3Q&list=PLvsOC5PoBqO5ggNxiqPKSkO_ZL5-JctbU

- Rythm assistant :
https://www.youtube.com/watch?v=u1Y226gDEoo&list=PLvsOC5PoBqO5ggNxiqPKSkO_ZL5-JctbU&index=2

- Scales assistant :
https://www.youtube.com/watch?v=C232B-3eK2Y&list=PLvsOC5PoBqO5ggNxiqPKSkO_ZL5-JctbU&index=4

- Chords assistant :
https://www.youtube.com/watch?v=-Vk3yYAOV_4&list=PLvsOC5PoBqO5ggNxiqPKSkO_ZL5-JctbU&index=3

### How to learn the piano as an autodidact?

It can be difficult to learn the piano on your own, for many reasons. This may be due to motivation (why continue), a lack of knowledge (without a musical ear, it is difficult to know if a chord is really correct, and in what context it is usable), or even a lack of means. (whether in space, or in money for a piano). The solution we have chosen is to create a piano with LeapMotion Controller, in order to address these issues.

### LeapMotion, a bridge with reality

To start, we used Unity and the Unity SDK from LeapMotion. This gave us various selection tools such as the pinching fingers. However, the usefulness being rather limited we decided to make a clean sweep of these features and we have so re made from almost zero. By placing boxcolliders at the end of fingers, we gained a system of simple collisions but easily expandable. We have therefore also introduced the concept of velocity. The latter calculates the speed of movement of the fingers by based on the $y$ position of the collider. This speed is calculated on a time interval that can be defined (if it is too low, a near-zero motion can be perceived as fast, so we found a compromise around 0.05s). As a reminder, the velocity present in the DAWs (digital audio workstation) describes the volume of the sound. The speed of movement of the finger therefore has a direct influence on the volume of the button pressed. Our formula, with $v$ for volume and $c$ for velocity will be : $$v = maximum(v_{max}, \frac{v_{max} * minimum(c_{max}, c)}{c_{max}})$$

### From C0 to C7... the range of a real piano at your fingertips

We also worked on the movement of the camera on the
piano. We need to control

- camera zoom

- the x position of the camera

For this, we calculate the difference of the two hands as an influencing variable
on the zoom, and the $x$ position of the center of the two hands to define the
position $x$ of the camera. Here is an example in the video below. Our formula will be:
$$center_x = \frac{pos_{left_x}+pos_{right_x}}{2}$$
$$zoom_y = pos_{camera_y} + \sqrt{pos_{left_x}^2 - pos_{right_x}^2}$$
$$pos_{camera} = (center_x, \frac{zoom_y-2}{screen_{width}*pos_{camera_{ymax}}}, pos_{camera_z})$$
-2 is a constant that we use in a conditional to avoid
micro tremors (we do not allow too much movement)
weak to avoid an unpleasant sensation.

You can see an example in action here : [vidéo
mouvement](https://www.youtube.com/watch?v=EnPYldUcp3Q&list=PLvsOC5PoBqO5ggNxiqPKSkO_ZL5-JctbU)

### Quantification at our service

What happens when we play? Can we play perfectly in tune? The answer is no, there will always be an accuracy human-related error. If we want to play at a time $t = 1s$, chances are that we play for example at $t = 0.98s$ or $t = 1.02s$. To not only reduce the problem but to eliminate it, we suggest to introduce the quantification. That is to say that the player chooses an interval of precision (like the sixteenth note if we refer to the musical lexical). We will therefore have time $t$ and quantification $q$ as variables.

A correction formula will therefore have to round our times to the closest quantified value. $$t' = round(\frac{t}{q}) * q$$ This first formula actually rounds correctly. If $x = 1.02$ and $q = 0.5$, then our time $t' = 1.00$. But there is one design error! One cannot correct a time which should be played before time t. In other words, $t' >= t$ is a condition for that correction works in our world. We will therefore have to add a latency equal to $\frac{q}{2}$ to be able to fix every $t \in [t'-q, t'+q]$. We get this formula: $$t' = round(\frac{t}{q}) * q + \frac{q}{2}$$ Finally, to hold account of the tempo, we need to normalize the quantization. This normalization will be represented as $nq = \frac{q}{tempo} * 60$. Thus, our final formula will become: $$t' = round(\frac{t}{nq}) * nq + \frac{nq}{2}$$ You can see a example at work here: [video
quantification](https://www.youtube.com/watch?v=u1Y226gDEoo&list=PLvsOC5PoBqO5ggNxiqPKSkO_ZL5-JctbU&index=2)

### Visual ranges for better memorization

To facilitate the learning of different musical scales, and to help find coherent melodies, we offer the player to choose a scale, which will be a working musical framework. All the keys that do not belong to the desired range are then disabled (not
produce more sound) and appear grayed out. Note that a D major scale will be correctly adjusted with respect to the shift in
semitone value. You can see an example in action here: [video range](https://www.youtube.com/watch?v=C232B-3eK2Y&list=PLvsOC5PoBqO5ggNxiqPKSkO_ZL5-JctbU&index=4)

### Instant feedback on your efforts: ChordsFinder

The next step for a good guide is to inform you in real time if
you just played a chord, and tell you which one more
precisely. As, in music, everything is cyclical (one C + 12 semitones
is a do), we approached this problem with a dictionary of chords
and a method of theoretical transposition. First, we start with
a dictionary. The latter will include a list of 12 semitones. By
example :

                new bool[] { true, false, false, false, 
                true, false, false, true, false, false, false, true }, // C major 7

Each semitone represents a note (do, d minor, d, etc\...). We
let's base everything on C and apply transpositions of $n$ semitones
such that $n$ is the number of semitones necessary for the note played
the lowest becomes a C. We then apply a subtraction of
semitones at each note played of $n$ values, and we get a list
of notes which, if is a chord, will probably be indexed by our
dictionary. If so, then the name of the chord found is
displayed on the screen. You can see an example in action here: [video
chords](https://www.youtube.com/watch?v=-Vk3yYAOV_4&list=PLvsOC5PoBqO5ggNxiqPKSkO_ZL5-JctbU&index=3)
